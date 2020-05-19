using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the type of action of a work order action.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WorkOrderActionType
    {
        /// <summary>
        /// Unknown action.
        /// </summary>
        Unknown,
        /// <summary>
        /// The action is a recipe creation.
        /// </summary>
        RecipeCreation,
        /// <summary>
        /// The action is a recipe modification.
        /// </summary>
        RecipeModification,
        /// <summary>
        /// The action is a recipe optimization.
        /// </summary>
        RecipeOptimization,
        /// <summary>
        /// The action is a pre production operation. Includes setup type activities, like feeder setup, stencil installation, paste application, etc.
        /// </summary>
        PreProductionOperations,
        /// <summary>
        /// The action is a post production operation. Includes breakdown, and other post-production activities.
        /// </summary>
        PostProductionOperations
    }
}
