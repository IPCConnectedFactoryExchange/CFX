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
    }
}