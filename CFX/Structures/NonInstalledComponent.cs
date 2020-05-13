using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a particular location on a production unit where materials / parts were not installed.
    /// </summary>
    public class NonInstalledComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NonInstalledComponent(bool setDateTime = false)
        {
            if (setDateTime) NonInstallationTime = DateTime.Now;
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
        /// The specific time when this material / part was tried to be installed on the production unit (optional, when known)
        /// </summary>
        public DateTime? NonInstallationTime
        {
            get;
            set;
        }

        /// <summary>
        /// The final location of the component that has not been installed
        /// </summary>
        public NonInstalledComponentLocation Location
        {
            get;
            set;
        }

        /// <summary>
        /// Id of the rejection box where the component has been rejected (if applicable)
        /// </summary>
        public string RejectionBoxId
        {
            get;
            set;
        }

        /// <summary>
        /// A comment on the rejection
        /// </summary>
        public string RejectionComment
        {
            get;
            set;
        }

        /// <summary>
        /// The reason of the rejection of this component (Unknown if not known)
        /// </summary>
        public RejectionReason RejectionReason
        {
            get;
            set;
        }
		
		/// <summary>
        /// The rejection details, depending on the rejection reason (optional)
        /// </summary>
        public RejectionDetails RejectionDetails
        {
            get;
            set;
        }
    }
}
