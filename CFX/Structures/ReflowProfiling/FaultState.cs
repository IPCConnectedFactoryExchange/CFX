using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.ReflowProfiling
{
    /// <summary>
    /// A dynamic structure which describes a fault that has occurred in the course of production.
    /// </summary>
    public class FaultState : Fault
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FaultState()
        {
            /// commenting out the defaults -- I do not think we want the redundancy
            /*Cause = FaultCause.MechanicalFailure;
            Severity = FaultSeverity.Information;
            FaultOccurrenceId = Guid.NewGuid();
            AccessType = AccessType.Unknown;
            SideLocation = SideLocation.Unknown;*/
        }

        /// <summary>
        /// Time and date of fault occurence in ISO 8061 Datetime format. 
        /// </summary>
        public string TimeDateFaultEvent
        {
            get;
            set;
        }
    }
}
