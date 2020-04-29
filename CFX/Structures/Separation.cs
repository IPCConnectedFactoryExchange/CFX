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
        /// Separation object name for Solder Paste Printing
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Separation speed value for Solder Paste Printing - UpdateRecipeRequest
        /// </summary>
        public double? Separation_Speed { get; set; }
        /// <summary>
        /// Separation distance for Solder Paste Printing - UpdateRecipeRequest
        /// </summary>
        public double? Separation_Distance { get; set; }
        /// <summary>
        /// Separation direction for Solder Paste Printing - UnitsProcessed 
        /// </summary>
        public string Separation_Direction { get; set; }
        /// <summary>
        /// Separation delay for Solder Paste Printing - UnitsProcessed 
        /// </summary>
        public double? Separation_Delay { get; set; }
    }
}
