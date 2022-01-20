using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para> ** NOTE: ADDED in CFX 1.4 **</para>
    /// Represents a collection of instructions used by a piece of automated equipment to perform
    /// a function (typically upon a production unit) during production. The RecipeLean does not deliver the Recipe data
    /// but RecipeName and Revision only. For the full Recipe data, please see <see cref="Recipe"/>.
    /// </summary>

    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    [CFX.Utilities.CreatedVersion("1.4")]
    public class RecipeIdentifier
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeIdentifier()
        {
        }

        /// <summary>
        /// The name of the recipe (may include full path, if applicable)
        /// </summary>
        public string RecipeName
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
    }
}
