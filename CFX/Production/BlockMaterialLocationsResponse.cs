using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to block or disable a particular material setup location. 
    /// This is typically used where a loaded material may become unsuitable for use, 
    /// for example MSD expiry of an SMT material.
    /// </summary>
    public class BlockMaterialLocationsResponse : CFXMessage
    {
        public BlockMaterialLocationsResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
    }
}
