using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Represents the generic sub-resources of a generic head. For example, camera 
    /// mounted on the head in a specific position
    /// </summary>
    public class HeadResource : ResourceInformation
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HeadResource()
        {
            
        }

        /// <summary>
        /// A list of camera located on the Head
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<Camera> Cameras
        {
            get;
            set;
        }

        /// <summary>
        /// If applicable, the rotation axis of the part located on the Head
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<RotationAxis> RotationAxes
        {
            get;
            set;
        }
    }
}
