using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace CFX.Utilities
{
    /// <summary>
    /// Allows for diagnostic logging of CFX transactions.
    /// </summary>
    public static class AppLog
    {
        static AppLog()
        {
            settingsPath = null;
            loadInterval = TimeSpan.FromSeconds(30);
            lastLoad = DateTime.Now - (loadInterval + TimeSpan.FromSeconds(10));

            settings = new AppLogSettings();
            LoggingEnabled = true;
            LogFilePath = null;
            LoggingLevel = LogMessageType.Error;

            LoadSettings();
            SetupAmqpLogging();

            //LoggingLevel = LogMessageType.Error | LogMessageType.Info;
            //File.WriteAllText("c:\\jjwtemp\\AppLogSettings.json", CFXJsonSerializer.SerializeObject(settings));
        }

        private static AppLogSettings settings;
        private static string settingsPath;
        private static TimeSpan loadInterval;
        private static DateTime lastLoad;
        private static object settingsLockObject = new object();
        private static object logLockObject = new object();
        private static object queueLockObject = new object();
        private static Queue<string> logEntries = new Queue<string>();

        public static event TraceListenerHandler OnTraceMessage;

        private static void LoadSettings()
        {
            if (string.IsNullOrWhiteSpace(SettingsPath)) return;

            lock (settingsLockObject)
            {
                if ((DateTime.Now - lastLoad) < loadInterval) return;
                lastLoad = DateTime.Now;

                try
                {
                    if (File.Exists(SettingsPath))
                    {
                        settings = CFXJsonSerializer.DeserializeObject<AppLogSettings>(File.ReadAllText(SettingsPath));
                        settings.LogFilePath = Environment.ExpandEnvironmentVariables(settings.LogFilePath);
                        SetupAmqpLogging();
                    }
                }
                catch (Exception ex)
                {
                    Error(ex);
                }
            }
        }

        private static void SetupAmqpLogging()
        {
            if (!settings.AmqpTraceEnabled)
            {
                Amqp.Trace.TraceLevel = 0;
                Amqp.Trace.TraceListener = null;
                return;
            }

            Amqp.TraceLevel level = 0;
            if ((settings.LoggingLevel & LogMessageType.Debug) != 0) level |= (Amqp.TraceLevel.Frame | Amqp.TraceLevel.Verbose | Amqp.TraceLevel.Output);
            if ((settings.LoggingLevel & LogMessageType.Warn) != 0) level |= Amqp.TraceLevel.Warning;
            if ((settings.LoggingLevel & LogMessageType.Error) != 0) level |= Amqp.TraceLevel.Error;
            if ((settings.LoggingLevel & LogMessageType.Info) != 0) level |= Amqp.TraceLevel.Information;

            Amqp.Trace.TraceLevel = level;
            if (level != 0) Amqp.Trace.TraceListener = (l, f, a) =>
            {
                string msg = string.Format(f, a);
                OnTraceMessage?.BeginInvoke(LogMessageType.Debug, msg, null, null);
                System.Diagnostics.Debug.WriteLine(msg);
                WriteMessageToLog(msg);
            };
        }

        public static string SettingsPath
        {
            get
            {
                return settingsPath;
            }
            set
            {
                settingsPath = value;
                if (!string.IsNullOrWhiteSpace(settingsPath))
                {
                    lastLoad = DateTime.Now - (loadInterval + TimeSpan.FromSeconds(10));
                    LoadSettings();
                }
            }
        }

        public static bool LoggingEnabled
        {
            get
            {
                return settings.LoggingEnabled;
            }
            set
            {
                lock (settingsLockObject)
                {
                    settings.LoggingEnabled = value;
                }
            }
        }

        public static string LogFilePath
        {
            get
            {
                return settings.LogFilePath;
            }
            set
            {
                lock (settingsLockObject)
                {
                    settings.LogFilePath = value;
                }
            }
        }

        public static LogMessageType LoggingLevel
        {
            get
            {
                return settings.LoggingLevel;
            }
            set
            {
                lock (settingsLockObject)
                {
                    settings.LoggingLevel = value;
                }

                SetupAmqpLogging();
            }
        }

        public static bool AmqpTraceEnabled
        {
            get
            {
                return settings.AmqpTraceEnabled;
            }
            set
            {
                lock (settingsLockObject)
                {
                    settings.AmqpTraceEnabled = value;
                }

                SetupAmqpLogging();
            }
        }

        public static void Info(string message)
        {
            Message(LogMessageType.Info, message);
        }

        public static void Warn(string message)
        {
            Message(LogMessageType.Warn, message);
        }

        public static void Debug(string message)
        {
            Message(LogMessageType.Debug, message);
        }

        private static void Message(LogMessageType type, string message)
        {
            LoadSettings();

            if ((LoggingLevel & type) == 0) return;
            System.Diagnostics.Debug.WriteLine(string.Format("{0}  {1}", type, message));
            OnTraceMessage?.BeginInvoke(type, message, null, null);

            if (!LoggingEnabled) return;
            string msg = FormatMessage(type, message);
            WriteMessageToLog(msg);
        }

        public static void Error(Exception ex)
        {
            Message(LogMessageType.Error, ex.Message);
            Message(LogMessageType.Error, ex.StackTrace);
        }

        public static void Error(string message)
        {
            Message(LogMessageType.Error, message);
        }

        private static void WriteMessageToLog(string message)
        {
            if (string.IsNullOrEmpty(LogFilePath)) return;

            try
            {
                lock (queueLockObject)
                {
                    logEntries.Enqueue(message);
                }
                Task.Run(() =>
                {
                    string theMsg = null;

                    do
                    {
                        theMsg = null;
                        lock (queueLockObject)
                        {
                            if (logEntries.Count > 0) theMsg = logEntries.Dequeue();
                        }

                        if (theMsg != null)
                        {
                            lock (logLockObject)
                            {
                                File.AppendAllText(LogFilePath, message + "\r\n");
                            }
                        }
                    }
                    while (theMsg != null);
                });
            }
            catch
            {
            }
        }

        private static string FormatMessage(LogMessageType type, string message)
        {
            return string.Format("{0,-8}{1,-36}{2}", type.ToString() + ":", DateTime.Now.ToString("o"), message);
        }
    }

    /// <summary>
    /// An flag type enumeration that indicates which types of messages should be recorded during CFX diagnostic logging.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum LogMessageType
    {
        /// <summary>
        /// Debug Level
        /// </summary>
        [Description("DEBUG")]
        Debug = 1,
        /// <summary>
        /// Information Level
        /// </summary>
        [Description("INFO")]
        Info = 2,
        /// <summary>
        /// Warning Level
        /// </summary>
        [Description("WARN")]
        Warn = 4,
        /// <summary>
        /// Error Level
        /// </summary>
        [Description("ERROR")]
        Error = 8,
        /// <summary>
        /// All Levels Recorded
        /// </summary>
        [Description("ALL")]
        All = 0xffff
    }

    public delegate void TraceListenerHandler(LogMessageType type, string traceMessage);
}
