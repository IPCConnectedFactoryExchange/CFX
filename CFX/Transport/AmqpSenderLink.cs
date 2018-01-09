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
        public AmqpSenderLink(Uri uri, string address) : base(address)
        {
            Queue = new DurableQueue(GetLinkFileName(uri, address));
            LinkType = LinkType.Sender;
        }

        protected static readonly char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();

        protected static string GetLinkFileName(Uri uri, string address)
        {
            string result = uri.Host;
            if (uri.Port != 0) result += string.Format("-{0}", uri.Port);
            result += "-" + address;

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
            foreach (CFXEnvelope env in envelopes) Queue.Enqueue(env);
            TriggerProcessing();
        }

        private void TriggerProcessing()
        {
            lock (this)
            {
                if (!Processing)
                {
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
                            AppLog.Error(ex);
                        }

                        if (success)
                        {
                            Queue.Dequeue(messages.Length);
                        }

                        int remainingCount = Queue.Count;
                        if (remainingCount > 0) AppLog.Info(string.Format("{0} messages transmitted.  {1} messages remaining in spool.", messages.Length, Queue.Count));
                    }
                }
                else
                {
                    Thread.Sleep(Convert.ToInt32(AmqpCFXEndpoint.ReconnectInterval.Value.TotalMilliseconds));
                    int remainingCount = Queue.Count;
                    if (remainingCount > 0) AppLog.Info(string.Format("No Connection.  {0} messages remaining in spool.", Queue.Count));
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
