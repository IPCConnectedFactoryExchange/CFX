using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Definition of Sleep State
    /// </summary>
    public class SleepState
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SleepState()
        {
            SleepType = SleepType.Awake;
            PowerSaving = 0;
            WakeupTime = 0;
        }

        /// <summary>
        /// An enumeration identifying this particular sleep state
        /// </summary>
        public SleepType SleepType
        {
            get;
            set;
        }

        /// <summary>
        /// Power consumption saving achieved through this sleep state.
        /// PowerSaving units are percentages
        /// </summary>
        public int PowerSaving
        {
            get;
            set;
        }

        /// <summary>
        /// Time interval required to go from the current sleep state to the "Awake" state.
        /// WakeupTime units are seconds
        /// </summary>
        public int WakeupTime
        {
            get;
            set;
        }

    }
}