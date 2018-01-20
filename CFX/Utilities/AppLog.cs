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
    public static class AppLog
    {
        static AppLog()
        {
            loadInterval = TimeSpan.FromSeconds(30);
            lastLoad = DateTime.Now - (loadInterval + TimeSpan.FromSeconds(10));

            settings = new AppLogSettings();
            settings.LogFilePath = "c:\\jjwtemp\\cfxlog.txt";
            string test = CFXJsonSerializer.SerializeObject(settings);

            LoggingEnabled = true;
            LogFilePath = null;
            LoggingLevel = LogMessageType.Error;
            LoadSettings();
        }

        private static AppLogSettings settings;
        private static TimeSpan loadInterval;
        private static DateTime lastLoad;
        private static object settingsLockObject = new object();
        private static object logLockObject = new object();
        private static object queueLockObject = new object();
        private static Queue<string> logEntries = new Queue<string>();

        private static void LoadSettings()
        {
            lock (settingsLockObject)
            {
                if ((DateTime.Now - lastLoad) < loadInterval) return;
                lastLoad = DateTime.Now;

                try
                {
                    string path = System.AppContext.BaseDirectory;
                    string[] files = Directory.GetFiles(path, "AppLogSettings.json");
                    if (files != null && files.Length > 0)
                    {
                        settings = CFXJsonSerializer.DeserializeObject<AppLogSettings>(File.ReadAllText(files[0]));
                    }
                }
                catch (Exception ex)
                {
                    Error(ex);
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

            if (!LoggingEnabled) return;
            string msg = FormatMessage(type, message);
            WriteMessageToLog(msg);
        }

        public static void Error(Exception ex)
        {
            Message(LogMessageType.Error, ex.Message);
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

    [Flags]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum LogMessageType
    {
        [Description("DEBUG")]
        Debug = 1,
        [Description("INFO")]
        Info = 2,
        [Description("WARN")]
        Warn = 4,
        [Description("ERROR")]
        Error = 8
    }

}
