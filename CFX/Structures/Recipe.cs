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

        public string Name
        {
            get;
            set;
        }

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
