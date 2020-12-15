using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Definition of Sleep State
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class SleepState
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SleepState()
        {
            SleepName = "Awake";
            PowerSaving = 0.0;
            WakeupTime = TimeSpan.FromSeconds(0.0);
        }

        /// <summary>
        /// A descriptive name for this sleep state
        /// </summary>
        public string SleepName
        {
            get;
            set;
        }

        /// <summary>
        /// Power consumption saving achieved through this sleep state.
        /// PowerSaving units are percentages
        /// </summary>
        public double PowerSaving
        {
            get;
            set;
        }

        /// <summary>
        /// Time interval required to go from the current sleep state to the "Awake" state.
        /// WakeupTime units are seconds
        /// </summary>
        public TimeSpan WakeupTime
        {
            get;
            set;
        }

    }
}