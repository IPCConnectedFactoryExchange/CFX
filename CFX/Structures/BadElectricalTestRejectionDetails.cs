using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on an bad electrical test of a component
    /// </summary>
    public class BadElectricalTestRejectionDetails : ComponentElectricalTest, RejectionDetails
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BadElectricalTestRejectionDetails()
        {
            Result = false;
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