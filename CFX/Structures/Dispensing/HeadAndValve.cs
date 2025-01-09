using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// Describes a particular valve and head combination that was used in the course of production.
    /// </summary>
    public class HeadAndValve : Tool
    {
        /// <summary>
        /// The name or identifier of the head associated with this dispensing valve.
        /// </summary>
        public string HeadId
        {
            get;
            set;
        }

        /// <summary>
        /// Sequence of this valve on the head
        /// </summary>
        public Int32 ValveSequence
        {
            get;
            set;
        }
    }
}
