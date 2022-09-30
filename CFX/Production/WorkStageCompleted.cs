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
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   },
    ///   "Result": "Completed",
    ///   "PerformanceImpacts": null
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

        /// <summary>
        /// An enumeration indicating the overall result of the Work transaction
        /// </summary>
        public WorkResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// The total amount of productive time (in ms) that is expected to process one unit or group of units (as in the case of a carrier or panelized PCB),
        /// assuming no blocked or starved conditions at the station. This does not include any non-productive time, such as transfer, positioning, etc.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public List<PerformanceImpact> PerformanceImpacts
        {
            get;
            set;
        }
    }
}
