using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Represents a collection of instructions used by a piece of automated equipment to perform
    /// a function (typically upon a production unit) during production.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]

    public class Recipe
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {
        }

        /// <summary>
        /// The name of the recipe (may include full path, if applicable)
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// An optional version number, e.g. “2.0”
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of time that is expected to process one unit or group of units (as in the case of a carrier or panelized PCB), 
        /// assuming no blocked or starved conditions at the station.  This includes both productive and non-productive time, such as transfer, 
        /// positioning, etc.
        /// </summary>
        public double ExpectedCycleTime
        {
            get;
            set;
        }

        /// <summary>
        /// The number of units that are to be processed simulataneously by this recipe.  For example, in the case of a 2 x 2 panelized PCB, this
        /// property would be 4 because 4 units (PCB's) are procesed at one time per work transaction.  In the case that a station processes a
        /// variable number of units per transaction, this should represent the average number of units expected to be processed per transaction.
        /// </summary>
        public double ExpectedUnitsPerWorkTransaction
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.2 **</para>
        /// Length (X-Axis) of the Units processed within this Recipe, in centimeters.  Parallel to direction of production flow.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public double? UnitLength
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.2 **</para>
        /// Width (Y-Axis) of the Units processed within this Recipe, in centimeters.  Perpendicular to direction of production flow when viewed from above.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public double? UnitWidth
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.2 **</para>
        /// Heigth (Z-Axis) of the Units processed within this Recipe, in centimeters.  Perpendicular to direction of production flow when viewed from the side.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public double? UnitHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The MIME type of the binary data contained by the RecipeData property.
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// A binary representation of the recipe data.
        /// </summary>
        public byte [] RecipeData
        {
            get;
            set;
        }
    }
}
