using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to request the setup requirements of the active recipe.
    /// The response lists the required materials and tools, along with the locations where 
    /// the materials/tools must be loaded.
    /// <code language="none">
    /// {
    ///   "Lane": "1",
    ///   "Stage": "1"
    /// }
    /// </code>
    /// </summary>
    public class GetRequiredSetupRequest : CFXMessage
    {
        /// <summary>
        /// An optional property designating the specific Lane.
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Stage.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
