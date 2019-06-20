using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Recipe
    {
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
        /// Information about the assembly(ies) that this Recipe is used to process.
        /// </summary>

        public Assembly Assembly
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
