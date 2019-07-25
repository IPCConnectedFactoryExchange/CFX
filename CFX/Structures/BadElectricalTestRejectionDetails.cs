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
    }
}