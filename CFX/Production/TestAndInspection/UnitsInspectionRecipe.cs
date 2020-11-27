using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Provides recipe information for Inspection devices. It was designed to provide context information for the
    /// existing UnitsInspected message
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class UnitsInspectionRecipe : Recipe
    {
        /// <summary>
        /// Provides the static recipe information for each Unit that is to be inspected
        /// </summary>
        public List<RecipeUnit> UnitsToInspect { get; set; }

       /// <summary>
       /// Generation data of the recipe
       /// </summary>
        public DateTime RecipeGenerationDate { get; set; }

        /// <summary>
        ///     Describes how the inspections were performed
        /// </summary>
        public InspectionMethod InspectionMethod { get; set; }
    }
}
