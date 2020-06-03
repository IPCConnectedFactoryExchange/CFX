using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Reasons why a recipe was modified at an endpoint
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecipeModificationReason
    {
        /// <summary>
        /// Unspecified reason
        /// </summary>
        Unspecified,
        /// <summary>
        /// Newly created recipe
        /// </summary>
        NewRecipe,
        /// <summary>
        /// New revision of an existing recipe
        /// </summary>
        NewRevision,
        /// <summary>
        /// Geometric information was updated
        /// </summary>
        UpdatedGeometry,
        /// <summary>
        /// Bill of Materials information was updated
        /// </summary>
        UpdatedBOM,
        /// <summary>
        /// Correction to positional information
        /// </summary>
        PositionalCorrection,
        /// <summary>
        /// Correction to rotational information
        /// </summary>
        RotationalCorrection,
        /// <summary>
        /// Correction to information needed by vision system.
        /// </summary>
        VisionSystemCorrection,
        /// <summary>
        /// NOTE:  ADDED in CFX 1.2
        /// The recipe has been deleted
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        RecipeDeleted,
    }
}
