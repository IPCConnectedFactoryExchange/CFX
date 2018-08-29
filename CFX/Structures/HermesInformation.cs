using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Structure that contains information related to an Endpoint's support of the Hermes standard.
    /// </summary>
    public class HermesInformation
    {
        /// <summary>
        /// Whether or not the Endpoint has Hermes support enabled.
        /// </summary>
        public bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// The specific version of Hermes supported by the Endpoint.
        /// </summary>
        public string Version
        {
            get;
            set;
        }
    }
}
