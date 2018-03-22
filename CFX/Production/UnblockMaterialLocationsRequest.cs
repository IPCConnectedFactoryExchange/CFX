using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to release a material locations block which was put
    /// into place by a previously sent BlockMaterialLocationsRequest
    /// </summary>
    public class UnblockMaterialLocationsRequest : CFXMessage
    {
        public UnblockMaterialLocationsRequest()
        {
            Locations = new List<MaterialLocation>();
        }

        /// <summary>
        /// A list of locations to be unblocked
        /// </summary>
        public List<MaterialLocation> Locations
        {
            get;
            set;
        }
    }
}
