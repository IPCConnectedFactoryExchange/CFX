using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.Processing.LaserMarking
{
    /// <summary>
    /// Sent by a process endpoint after a unit undergoes a laser processing. Provides information regarding the experience of the unit during the laser processing.
    /// <code language="none">
    /// {
    ///   "TransactionId": "7e712504-4d65-499f-9dcb-1974e20bae59",
    ///   "RecipeProcessingTime": "0:0:25",
    /// }
    /// </code>
    /// </summary>
    public class UnitsLaserProcessed : CFXMessage
    {
        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Total amount of time that the laser was used during processing.
        /// </summary>
        public TimeSpan LaserProcessingTime
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the active recipe at the time when the processing occurred.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }
    }
}
