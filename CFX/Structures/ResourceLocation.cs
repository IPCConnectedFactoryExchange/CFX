using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// Describes a resource location
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ResourceLocation
    {
        /// </summary>
        /// The Resource on which the material is located (optional)
        /// If null, it is assumed that the Resource is the one associated to the source Endpoint of the message
        /// </summary>
        public Resource Resource
        {
            get;
            set;
        }

        /// <summary>
        /// Optional details on the location. Ingored if set to null.
        /// This is a dynamic structure.
        /// </summary>
        public LocationDetail LocationDetail
        {
            get;
            set;
        }

        /// <summary>
        /// An upper level ResourceLocation in which this ResourceLocation is located (optional)
        /// </summary>
        public ResourceLocation ParentResourceLocation
        {
            get;
            set;
        }
    }
}
