using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Production
{
    /// <summary>
    /// Sent when activity recommences at a stage within a process endpoint, following a WorkStagePaused message
    /// </summary>
    public class WorkStageResumed : CFXMessage
    {
        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// The stage name or number
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
