using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Structures.SolderPasteInspection
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Provides recipe information for Solder Paste Inspection devices. It was designed to provide context information for the
    /// existing UnitsInspected message
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class SolderPasteInspectionRecipe : Recipe
    {
        /// <summary>
        /// Provides the static recipe information for each Unit that is to be inspected
        /// </summary>
        [Newtonsoft.Json.JsonProperty(Order = 1)]
        public List<UnitToInspect> UnitsToInspect { get; set; }

        /// <summary>
        /// Generation data of the recipe
        /// </summary>
        [Newtonsoft.Json.JsonProperty(Order = 1)]
        public DateTime RecipeGenerationDate { get; set; }

        /// <summary>
        ///     Describes how the inspections were performed
        /// </summary>
        [Newtonsoft.Json.JsonProperty(Order = 1)]
        public InspectionMethod InspectionMethod { get; set; }
    }
}
