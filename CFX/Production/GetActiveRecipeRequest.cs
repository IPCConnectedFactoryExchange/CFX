using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Used to request the name of the recipe that is activated at a process
    /// endpoint. The response indicates the name of the recipe.
    /// <code language="none">
    /// {
    ///   "Lane": 1,
    ///   "Stage": null
    /// }
    /// </code>
    /// </summary>
    public class GetActiveRecipeRequest : CFXMessage
    {
        /// <summary>
        /// The optional number of the production lane
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The optional structure identifying the specific Stage
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
