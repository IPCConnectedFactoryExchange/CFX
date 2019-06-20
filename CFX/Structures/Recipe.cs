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
