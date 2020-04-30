using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures;

namespace CFX.Structures
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Separation
    {
        /// <summary>
        /// Separation object name for Solder Paste Printing. For future use.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Separation speed value for Solder Paste Printing - UpdateRecipeRequest
        /// </summary>
        public double? SeparationSpeed { get; set; }
        /// <summary>
        /// Separation distance for Solder Paste Printing - UpdateRecipeRequest
        /// </summary>
        public double? SeparationDistance { get; set; }
        /// <summary>
        /// Separation direction for Solder Paste Printing - UnitsProcessed 
        /// </summary>
        public string SqueegeeDirection { get; set; }
        /// <summary>
        /// Separation delay for Solder Paste Printing. For future use.
        /// </summary>
        public double? SeparationDelay { get; set; }
    }
}
