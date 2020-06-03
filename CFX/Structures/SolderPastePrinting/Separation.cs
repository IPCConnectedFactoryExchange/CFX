using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// NOTE:  ADDED in CFX 1.2
    /// Describes the separation structure as modelled in the SolderPastePrintingRecipe
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    [CFX.Utilities.CreatedVersion("1.2")]
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
        /// Separation delay for Solder Paste Printing. For future use.
        /// </summary>
        public double? SeparationDelay { get; set; }
    }
}
