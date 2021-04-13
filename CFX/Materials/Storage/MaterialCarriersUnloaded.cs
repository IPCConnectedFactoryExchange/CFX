using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when a material carrier (typcially containing 1 or more material packages)
    /// is unloaded at a process endpoint.
    /// <code language="none">
    /// {
    ///   "CarrierIdentifiers": [
    ///     "1233334",
    ///     "1233334"
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialCarriersUnloaded : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
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
