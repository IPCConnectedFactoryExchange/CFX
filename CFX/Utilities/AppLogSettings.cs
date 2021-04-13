using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Utilities
{
    /// <summary>
    /// A class representing CFX diagnostic log settings
    /// </summary>
    public class AppLogSettings
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AppLogSettings()
        {
            LoggingEnabled = true;
            LogFilePath = null;
            LoggingLevel = LogMessageType.Error | LogMessageType.Info;
            AmqpTraceEnabled = false;
        }

        /// <summary>
        /// Global enable/disable flag for logging.  If false, all CFX diagnostic logging is disabled.
        /// </summary>
        public bool LoggingEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// The full path and filename where diagnostic log entries should be written.  If null or empty, no log is written to disk.
        /// </summary>
        public string LogFilePath
        {
            get;
            set;
        }

        /// <summary>
        /// A flag type enumeration indicating which logging levels are to be enabled
        /// </summary>
        public LogMessageType LoggingLevel
        {
            get;
            set;
        }

        /// <summary>
        /// If true, transport oritented diagnostic trace information from the underlying Microsoft Amqp.Net library will also
        /// be included in the CFX diagnostic logs
        /// </summary>
        public bool AmqpTraceEnabled
        {
            get;
            set;
        }
    }
}
