﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent when activity pauses for some reason at a stage of the process endpoint
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class WorkStagePaused : CFXMessage
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
        /// The stage name or number
        /// </summary>
        public WorkStagePauseReason PauseReason
        {
            get;
            set;
        }
    }
}
