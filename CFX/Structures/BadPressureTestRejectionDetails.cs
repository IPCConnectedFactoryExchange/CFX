using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a bad pressure test
    /// </summary>
    public class BadPressureTestRejectionDetails : ComponentPressureTest, RejectionDetails
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BadPressureTestRejectionDetails()
        {
            Result = false;
        }
    }
}
