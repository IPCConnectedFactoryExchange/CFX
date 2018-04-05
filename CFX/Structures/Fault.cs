using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// A dynamic structure which describes a fault that has occurred in the course of production.
    /// May be one of:  <see cref="CFX.Structures.Fault"/>, <see cref = "CFX.Structures.SMTPlacement.SMTPlacementFault" />,
    /// <see cref="CFX.Structures.SolderPastePrinting.SMTSolderPastePrintingFault"/>, or <see cref="CFX.Structures.THTInsertion.THTInsertionFault"/>
    /// </summary>
    public class Fault
    {
        public Fault()
        {
            Cause = FaultCause.MechanicalFailure;
            Severity = FaultSeverity.Information;
            FaultOccurrenceId = Guid.NewGuid();
        }

        /// <summary>
        /// The cause of this fault.
        /// </summary>
        public FaultCause Cause
        {
            get;
            set;
        }

        /// <summary>
        /// The severity of the fault
        /// </summary>
        public FaultSeverity Severity
        {
            get;
            set;
        }

        /// <summary>
        /// An endpoint specific code indicating the nature of the fault
        /// </summary>
        public string FaultCode
        {
            get;
            set;
        }

        /// <summary>
        /// A 128-bit unique identifier which uniquely identifier this specific 
        /// occurrence of the fault
        /// </summary>
        public Guid FaultOccurrenceId
        {
            get;
            set;
        }

        /// <summary>
        /// The production lane related to this fault (if applicable)
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The production stage related to this fualt (if applicable)
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
