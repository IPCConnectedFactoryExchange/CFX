using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate that a stage has been completed.
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "Stage": "1",
    ///   "Result": "Completed"
    /// }
    /// </code>
    /// </summary>
    public class WorkStageCompleted : CFXMessage
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
        public Stage Stage
        {
            get;
            set;
        }

        public WorkResult Result
        {
            get;
            set;
        }
    }
}
