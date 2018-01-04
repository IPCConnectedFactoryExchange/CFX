using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecipeModificationReason
    {
        Unspecified,
        NewRecipe,
        NewRevision,
        UpdatedGeometry,
        UpdatedBOM,
        PositionalCorrection,
        RotationalCorrection,
        VisionSystemCorrection,
    }
}
