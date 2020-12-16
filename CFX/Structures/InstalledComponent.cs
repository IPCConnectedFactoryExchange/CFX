using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a particular location on a production unit where materials / parts were installed.
    /// </summary>
    public class InstalledComponent
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InstalledComponent(bool setDateTime = false)
        {
            if (setDateTime) InstallationTime = DateTime.Now;
        }

        /// <summary>
        /// Location on production unit where material / parts were installed
        /// </summary>
        public string ReferenceDesignator
        {
            get;
            set;
        }

        /// <summary>
        /// The specific time when this material / part was installed on the production unit (optional, when known)
        /// </summary>
        public DateTime? InstallationTime
        {
            get;
            set;
        }

        /// <summary>
        /// The electrical test result of this component (optional)
        /// </summary>
        public ComponentElectricalTest ElectricalTest
        {
            get;
            set;
        }
    }
}
