using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX;
using CFX.Structures;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// NOTE:  ADDED in CFX 1.2
    /// Describes the Solder paste printing structure 
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class SolderPastePrintingRecipe : Recipe
    {
        /// <summary>
        /// Class constructor for the derived Class SolderPastePrintingRecipe
        /// </summary>
        public SolderPastePrintingRecipe()
        {

        }
        /// <summary>
        /// List of Stroke objects for Solder Paste Printing
        /// </summary>
        public List<Stroke> Strokes { get; set; }
        /// <summary>
        /// Print gap value 
        /// </summary>
        public double? PrintGap { get; set; }
        /// <summary>
        /// Separation object 
        /// </summary>
        public Separation Separation { get; set; }
        /// <summary>
        /// Periodic cleaning object List. Normally it shall be one, but in this way it may be extended more easily 
        /// </summary>
        public List<PeriodicCleaning> PeriodicCleanings { get; set; }
    }
}
