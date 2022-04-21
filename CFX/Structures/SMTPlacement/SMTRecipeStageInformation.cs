
using System.Collections.Generic;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Describes some information about a recipe for a specific stage, with more information for an SMT machine
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class SMTRecipeStageInformation : RecipeStageInformation
    {
        /// <summary>
        /// List of heads that are associated with this stage for the given recipe, if applicable.
        /// </summary>
        public List<Head> Heads
        {
            get;
            set;
        }
    }
}
