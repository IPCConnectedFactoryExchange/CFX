using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when the work-stage for a unit or group of units starts
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "Stage": "1"
    /// }
    /// </code>
    /// </summary>
    public class WorkStageStarted : CFXMessage
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
