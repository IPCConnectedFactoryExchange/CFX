using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Amqp;
using CFX.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace CFX.Transport
{
    internal class AmqpSenderLink : AmqpLink, IDisposable
    {
        public AmqpSenderLink(Uri uri, string address, string sourceHandle) : base(address)
        {
            Queue = new DurableQueue(GetLinkFileName(uri, address, sourceHandle));
            LinkType = LinkType.Sender;
        }

        protected static readonly char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();

        protected static string GetLinkFileName(Uri uri, string address, string sourceHandle)
        {
            string result = uri.Host;
            if (uri.Port != 0) result += string.Format("-{0}", uri.Port);
            result += "-" + address;
            result += "-" + sourceHandle;

            result = new string(result.Select(ch => invalidFileNameChars.Contains(ch) ? '_' : ch).ToArray());
            return result;
        }

        public SenderLink SenderLink
        {
            get
            {
                return Link as SenderLink;
            }
            set
            {
                Link = value;
            }
        }

        public DurableQueue Queue
        {
            get;
            set;
        }

        public int SpoolSize
        {
            get
            {
                return Queue.Count;
            }
        }

        private void LogInfo(string message)
        {
            AppLog.Info($"sender-{Address}  {message}");
        }

        private void LogDebug(string message)
        {
            AppLog.Debug($"sender-{Address}  {message}");
        }

        private void LogWarn(string message)
        {
            AppLog.Warn($"sender-{Address}  {message}");
        }

        private void LogError(Exception ex)
        {
            AppLog.Error($"sender-{Address}  {ex.Message}");
            AppLog.Error(ex);
        }

        private Task processingTask = null;

        private bool Processing
        {
            get
            {
                lock (this)
                {
                    return processingTask != null && !(processingTask.IsCompleted || processingTask.IsFaulted);
                }
            }
        }

        public void Publish(CFXEnvelope [] envelopes)
        {
            LogDebug($"Enqueuing {envelopes.Length} messages.");
            foreach (CFXEnvelope env in envelopes) Queue.Enqueue(env);
            TriggerProcessing();
        }

        private void TriggerProcessing()
        {
            lock (this)
            {
                if (!Processing)
                {
                    LogDebug("Triggering Processing...");
                    processingTask = Task.Run(() =>
                    {
                        Process();
                    });
                }
            }
        }

        private void Process()
        {
            while (!Queue.IsEmpty)
            {
                LogDebug("Attempting to process queued messages...");

                bool success = false;
                if (!IsClosed)
                {
                    CFXEnvelope[] messages = Queue.PeekMany(AmqpCFXEndpoint.MaxMessagesPerTransmit.Value);
                    if (messages != null && messages.Any())
                    {
                        try
                        {
                            Message msg = AmqpUtilities.MessageFromEnvelopes(messages, AmqpCFXEndpoint.UseCompression.Value);
                            SenderLink.Send(msg);
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            LogError(ex);
                            AppLog.Error(ex);
                        }

                        if (success)
                        {
                            Queue.Dequeue(messages.Length);
                        }

                        int remainingCount = Queue.Count;
                        if (success)
                            LogDebug($"{messages.Length} messages transmitted.  {Queue.Count} messages remaining in spool.");
                        else
                            LogDebug($"Messages NOT transmitted.  {Queue.Count} messages remaining in spool.");

                        if (remainingCount > 90) LogWarn(string.Format("Warning.  Spool has {0} buffered messages.", remainingCount));
                    }
                }
                else
                {
                    Thread.Sleep(Convert.ToInt32(AmqpCFXEndpoint.ReconnectInterval.Value.TotalMilliseconds));
                    int remainingCount = Queue.Count;
                    if (remainingCount > 0) LogWarn($"Connection Bad or Error.  {Queue.Count} messages remaining in spool.");
                }
            }
        }

        public override bool CreateLink(Session session)
        {
            if (!base.CreateLink(session)) return false;

            SenderLink sender = null;

            Task.Run(() =>
            {
                try
                {
                    sender = new SenderLink(session, Address, Address);
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                    sender = null;
                }
            }).Wait();

            this.SenderLink = sender;
            return true;
        }
    }
}
