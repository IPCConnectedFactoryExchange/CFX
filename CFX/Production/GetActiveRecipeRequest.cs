using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// Used to request the name of the recipe that is activated at a process
    /// endpoint. The response indicates the name of the recipe.
    /// <code language="none">
    /// {
    ///   "Lane": "1",
    ///   "Stage": "1"
    /// }
    /// </code>
    /// </summary>
    public class GetActiveRecipeRequest : CFXMessage
    {
        /// <summary>
        /// The optional name or number of the production lane
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The optional name or number of the stage
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
