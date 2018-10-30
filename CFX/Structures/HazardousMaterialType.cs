using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Specifies whether or not a material is hazardous, and if so, the regulatory directive that controls
    /// the use of this substance in production.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HazardousMaterialType
    {
        /// <summary>
        /// The material is not hazardous
        /// </summary>
        NotHazardous,
        /// <summary>
        /// The material is not hazardous, but not subject to any particular directives.
        /// </summary>
        Hazardous,
        /// <summary>
        /// The material is hazardoes, and is subject to the Restriction of Hazardous Substances Directive
        /// (RoHS)
        /// </summary>
        RoHS,
    }
}
