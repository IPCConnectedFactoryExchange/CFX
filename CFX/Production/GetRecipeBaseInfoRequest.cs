using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Used to request the name of the recipe base info with the recipe description for the
    /// inspection equipment
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPENAMEA",
    ///   "Guid": "66B1D889-65B2-4100-8CAF-C78DDE447941"
    /// }
    /// </code>
    /// <remarks>
    /// If a Inspection program changes several times within a in inspection session (batch of boards), the AOI is supposed to send the RecipeBaseInfo
    /// Message along with RecipeActivated message before that modified Inspection Program becomes active on the AOI.
    /// This ensures that the AOI Event consumers always have consistent context information.Each RecipeBaseInfo message as a different RecipeID
    /// to distinguish the different recipe versions.
    /// </remarks>
    /// </summary>
    public class GetActiveRecipeBaseInfoRequest
    {
        /// <summary>
        /// This is the recipe name that is contained in the RecipeBaseInfo message
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// The optional RecipeID specifies the variant/version of the recipes if several versions are available.
        /// <remarks>
        /// If an AOI doesn’t keep all the Program changes it can  ignore the RecipeID in the GetRecipeBaseInfo request and send the latest available RecipeBaseinfo Panel instead.
        /// </remarks>
        /// </summary>
        public Guid RecipeId
        {
            get;
            set;
        }
    }
}
