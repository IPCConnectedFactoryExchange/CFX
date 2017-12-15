using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    public class MaterialCarriersUnloaded : CFXMessage
    {
        public MaterialCarriersUnloaded()
        {
            CarrierIdentifiers = new List<string>();
        }

        /// <summary>
        /// List of carriers to be unloaded.  
        /// NOTE - This message DOES NOT mean that the MaterialPackage is unloaded from the MaterialCarrier.
        ///        Only that the MaterialCarrier is unloaded from its parent (slot on and Endpoint, or another MaterialCarrier).
        /// </summary>
        public List<string> CarrierIdentifiers
        {
            get;
            set;
        }

    }
}
