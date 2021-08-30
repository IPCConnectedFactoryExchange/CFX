using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// This message is used to request a process endpoint for the available recipes.
    /// The response includes the list of the recipes, with a maximun specified by the MaxCount parameter
    /// <code language="none">
    /// {
    ///   "Path": "myRecipes/CFX/A-Team*",
    ///   "MaxCount": 5
    /// }
    /// </code>
    /// </summary>
    public class GetAvailableRecipesRequest : CFXMessage
    {
        /// <summary>
        /// Pathname with wildcard, e.g. “myRecipes/CFX/A-Team*”.
        /// </summary>
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Max. number of recipes that may be returned with the response.
        /// </summary>
        public int MaxCount
        {
            get;
            set;
        }
    }
}
