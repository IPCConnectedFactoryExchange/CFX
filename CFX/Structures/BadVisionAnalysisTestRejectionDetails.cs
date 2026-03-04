using System.Collections.Generic;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Describes details on a bad vision analysis test
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class BadVisionAnalysisTestRejectionDetails : List<ComponentVisionAnalysisTest>, RejectionDetails
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BadVisionAnalysisTestRejectionDetails()
        {
        }

        /// <summary>
        /// Source of decision for the component validity
        /// </summary>
        public ComponentValidityDecisionSource DecisionSource
        {
            get;
            set;
        }

        /// <summary>
        /// A vendor-specific string based code identifying
        /// the specific error that has caused the rejection
        /// of the component
        /// </summary>
        public string ErrorCode
        {
            get;
            set;
        }
    }
}
