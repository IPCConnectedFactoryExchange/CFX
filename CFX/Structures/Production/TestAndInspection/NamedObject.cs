using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CFX.Structures.Production.TestAndInspection
{

    /// <summary>
    /// An object that can be identified by its name.
    /// </summary>
    public class NamedObject
    {
        /// <summary>
        /// The name of this object, like "C1", "R1", "Fiducial_1", "Pin1"
        /// </summary>
        [JsonProperty (Order = -3)]  // The name should come at the very beginning.
        public String Name { get; set; }
    }

}
