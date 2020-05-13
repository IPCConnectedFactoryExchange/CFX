using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a bad optical test
    /// </summary>
    public class BadOpticalTestRejectionDetails : ComponentOpticalTest, RejectionDetails
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BadOpticalTestRejectionDetails()
        {
            Result = false;
        }
    }
}
