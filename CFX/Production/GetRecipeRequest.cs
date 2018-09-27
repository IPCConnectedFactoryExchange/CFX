using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to request a process endpoint for the details of a named
    /// recipe. The response includes details of the recipe, depending on the 
    /// classification of the process.
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE3234",
    ///   "Revision": null
    /// }
    /// </code>
    /// </summary>
    public class GetRecipeRequest : CFXMessage
    {
        /// <summary>
        /// The name of the recipe to be retrieved (may include full path, if applicable)
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
    }
}
