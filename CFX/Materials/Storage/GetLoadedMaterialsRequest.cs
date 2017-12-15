using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    public class GetLoadedMaterialsRequest : CFXMessage
    {
        /// <summary>
        /// An optional list of specific locations in which the requestor is interested.
        /// If empty, all materials loaded at the Endpoint are returned.
        /// </summary>
        public List<string> LocationIdentifiers
        {
            get;
            set;
        }
    }
}
