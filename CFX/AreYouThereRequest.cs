using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to determine if another particular CFX endpoint is present on a CFX network.
    /// The response sends basic information about the endpoint, including its CFX Handle, and network
    /// hostname / address.
    /// </summary>
    public class AreYouThereRequest : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint to which the request is directed
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }
    }
}
