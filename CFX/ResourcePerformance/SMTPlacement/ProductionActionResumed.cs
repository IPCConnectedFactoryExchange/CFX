using CFX.Structures;
using System;

namespace CFX.ResourcePerformance.SMTPlacement
{
    /// <summary>
    /// Sent by an SMT placement machine to indicate the resuming of an action
    /// <code language="none">
    /// {
    ///   "ProductionAction": "BoardAlignment"
    ///   "TransactionId": "8561b98b-21ba-47e6-810d-0917b58a4415",
    /// }
    /// </code>
    /// </summary>
    public class ProductionActionResumed : CFXMessage
    {
        /// <summary>
        /// The resumed action
        /// </summary>
        public SMTProductionAction ProductionAction
        {
            get;
            set;
        }
		
	/// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }
		
	/// <summary>
        /// The name or number of the stage
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
		
	/// <summary>
        /// The name or number of the head
        /// </summary>
        public string Head
        {
            get;
            set;
        }
    }
}

