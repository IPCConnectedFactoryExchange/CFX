using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes addition detail for material packages containing moisture 
    /// sensitive devices
    /// </summary>
    public class MaterialPackageMSDData : MaterialPackageData
    {
        /// <summary>
        /// In the case where the MSD material is open and currently exposed to the
        /// environment, the date / time when the MSD material will expire rendering it
        /// no longer able to be used in production.  Otherwise null.
        /// </summary>
        public DateTime? ExpirationDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this MSD material was originally opened and exposed to
        /// the environment
        /// </summary>
        public DateTime? OriginalExposureDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// In the case where the MSD material is open and currently exposed to the environment,
        /// the date / time when the material was most recently opened and/or exposed.  Otherwise null.
        /// </summary>
        public DateTime? LastExposureDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of time before the MSD expires, rendering it unable to be used in production
        /// (assuming the material is open and exposed to the environment)
        /// </summary>
        public TimeSpan? RemainingExposureTime
        {
            get;
            set;
        }

        /// <summary>
        /// The level of moisture sensitivity (as defined by IPC/JEDEC J-STD-033C)
        /// </summary>
        public MSDLevel MSDLevel
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration describing the current state of this MSD material
        /// </summary>
        public MSDState MSDState
        {
            get;
            set;
        }
    }
}
