using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.2 **</para>
    /// Describes the type of action of a work order action.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("1.2")]
    public enum WorkOrderActionType
    {
        /// <summary>
        /// Activity does not fall into any of the pre-defined categories.
        /// </summary>
        Uncategorized = 0,
        /// <summary>
        /// The action is a recipe creation.
        /// </summary>
        RecipeCreation = 100,
        /// <summary>
        /// The action is a recipe modification.
        /// </summary>
        RecipeModification = 200,
        /// <summary>
        /// The action is a recipe optimization.
        /// </summary>
        RecipeOptimization = 300,
        /// <summary>
        /// The action is a pre production operation.
        /// </summary>
        PreProductionOperations = 400,
        /// <summary>
        /// The action is a pre production operation, related to material setup. Includes activities like feeder setup, paste application, etc.
        /// </summary>
        PreProductionOperations_MaterialSetup = 401,
        /// <summary>
        /// The action is a pre production operation, related to tooling setup. Includes setup type activities like stencil installation, etc.
        /// </summary>
        PreProductionOperations_ToolingSetup = 402,
        /// <summary>
        /// The action is a pre production operation, related to other types of setup.
        /// </summary>
        PreProductionOperations_OtherSetup = 403,
        /// <summary>
        /// The action is a pre production operation, related to quality checks, like first article runs and other quality pre-production activities.
        /// </summary>
        PreProductionOperations_QualityChecks = 404,
        /// <summary>
        /// The action is a pre production operation, related to the material selection, like selectiing and reserving the materials necessary for the production
        /// </summary>
        PreProductionOperations_MaterialSelection = 405,
        /// <summary>
        /// The action is a pre production operation, related to the material kitting, like picking the materials necessary for the production
        /// </summary>
        PreProductionOperations_MaterialKitting = 406,
        /// <summary>
        /// The action is a post production operation. Includes breakdown, and other post-production activities.
        /// </summary>
        PostProductionOperations = 500,
        /// <summary>
        /// The action is a mid production operation.
        /// </summary>
        MidProductionOperations = 600,
        /// <summary>
        /// The action is a mid production operation, related to replenishment of materials, such as feeder resplenishment, new paste application, etc. 
        /// </summary>
        MidProcuctionOperations_MaterialReplenish = 601,
    }
}
