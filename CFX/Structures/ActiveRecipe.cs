using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para> ** NOTE: ADDED in CFX 1.7 **</para>
    /// Represents a recipe active on a certain lane inside of a machine.
    /// This is equivalent to the information present in a <see cref="CFX.Production.RecipeActivated"/> message
    /// but represented as a structure so that it can be included in the <see cref="CFX.Heartbeat"/>
    /// message.
    /// </summary>

    [CFX.Utilities.CreatedVersion("1.7")]
    public class ActiveRecipe
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ActiveRecipe()
        {
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

        /// <summary>
        /// The identifier of the active recipe.
        /// If the complete recipe is known, Recipe should be used instead.
        /// </summary>
        public RecipeIdentifier RecipeIdentifier;

        /// <summary>
        /// The details of the active recipe.
        /// If the recipe details are not known then RecipeIdentifier should
        /// be used instead.
        /// </summary>
        public Recipe Recipe;
    }
}
