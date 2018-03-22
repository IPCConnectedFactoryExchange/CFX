using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate the activation of a recipe by its name
    /// </summary>
    public class RecipeActivated : CFXMessage
    {
        /// <summary>
        /// THe name of the recipe
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0”
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// Name or number of the production lane
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// Name or number of the stage
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
