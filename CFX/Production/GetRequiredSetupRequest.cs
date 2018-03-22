using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to request the setup requirements of the active recipe.
    /// The response lists the required materials and tools, along with the locations where 
    /// the materials/tools must be loaded.
    /// </summary>
    public class GetRequiredSetupRequest : CFXMessage
    {
        /// <summary>
        /// An optional property designating the specific Lane.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Stage.
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
