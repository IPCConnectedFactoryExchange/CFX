using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate the activation of a recipe by its name
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE3234",
    ///   "Revision": "B",
    ///   "Lane": 1,
    ///   "Stage": null
    /// }
    /// </code>
    /// </summary>
    public class RecipeActivated : CFXMessage
    {
        /// <summary>
        /// THe name of the recipe (may include full path, if applicable)
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0” (Optional)
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// Number of the production lane (if applicable)
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional stage
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
