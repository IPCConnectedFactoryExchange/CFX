using CFX.Structures;
using System;

namespace CFX.ResourcePerformance.SMTPlacement
{
    /// <summary>
    /// Sent by an SMT placement machine to indicate the end of an action
    /// <code language="none">
    /// {
    ///   "ProductionAction": "BoardAlignment"
    ///   "TransactionId": "8561b98b-21ba-47e6-810d-0917b58a4415",
    /// }
    /// </code>
    /// </summary>
    public class ProductionActionCompleted : CFXMessage
    {
        /// <summary>
        /// The completed action
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
    }
}