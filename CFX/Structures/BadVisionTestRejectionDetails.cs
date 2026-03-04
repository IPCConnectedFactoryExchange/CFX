using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a bad vision test
    /// </summary>
    public class BadVisionTestRejectionDetails : List<ComponentVisionTest>, RejectionDetails
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BadVisionTestRejectionDetails()
        {
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// Source of decision for the component validity
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public ComponentValidityDecisionSource DecisionSource
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// A vendor-specific string based code identifying
        /// the specific error that has caused the rejection
        /// of the component
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public string ErrorCode
        {
            get;
            set;
        }
    }
}
