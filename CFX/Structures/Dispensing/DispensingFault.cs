using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// A specific type of fault that is produced by endpoints responsible for dispensing.
    /// </summary>
    public class DispensingFault : Fault
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DispensingFault()
        {
            DispensingFaultType = DispensingFaultType.PickupError;
            HeadAndValve = new HeadAndValve();
            MaterialLocation = new MaterialLocation();
        }

        /// <summary>
        /// The dispensing head and valve related to this fault (where applicable)
        /// </summary>
        public HeadAndValve HeadAndValve
        {
            get;
            set;
        }

        /// <summary>
        /// The material carrier location related to this fault (where applicable)
        /// </summary>
        public MaterialLocation MaterialLocation
        {
            get;
            set;
        }

        /// <summary>
        /// A specific type of dispensing fault
        /// </summary>
        public DispensingFaultType DispensingFaultType
        {
            get;
            set;
        }
    }
}
