using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Used to activate a named recipe at the process endpoint. 
    /// The response indicates whether this was successful or not.
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE1234",
    ///   "Revision": "C",
    ///   "Lane": 1,
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class ActivateRecipeRequest : CFXMessage
    {
        /// <summary>
        /// The name of the recipe. (may include full path, if applicable)
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// The version indicator for the recipe (optional)
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// The optional number of the production lane where 
        /// the recipe should be activated
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The optional name or number of the stage where
        /// the recipe should be activated
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
