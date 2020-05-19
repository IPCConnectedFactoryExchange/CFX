using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to send a named recipe to a process endpoint. The message
    /// includes details of the recipe, depending on the classification of the process. 
    /// The response indicates whether the recipe has been received correctly or not.
    /// <para>UpdateRecipeRequest JSON example</para>
    /// <code language="none">
    /// {
    ///   "Overwrite": true,
    ///   "Recipe": {
    ///     "Name": "RECIPE234324",
    ///     "Revision": "C",
    ///     "ExpectedCycleTime": 0.0,
    ///     "ExpectedUnitsPerWorkTransaction": 0.0,
    ///     "UnitLength": 22.46,
    ///     "UnitWidth": 19.21,
    ///     "UnitHeight": 0.85,
    ///     "MimeType": "application/octet-stream",
    ///     "RecipeData": "//w0"
    ///   },
    ///   "Reason": "NewRevision"
    /// }
    /// </code>
    /// <para>Load Printer Recipe / Modify Printer Recipe based on UpdateRecipeRequest and UpdateRecipeResponse </para>
    /// <code language="none">
    /// {
    ///   "Overwrite": true,
    ///   "Recipe": {
    ///     "$type": "CFX.Structures.SolderPastePrinting.SolderPastePrintingRecipe, CFX",
    ///     "Strokes": [
    ///       {
    ///         "PrintPressure": 1.0,
    ///         "PrintSpeed": 12.0
    ///       },
    ///       {
    ///         "PrintPressure": 2.0,
    ///         "PrintSpeed": 9.0
    ///       }
    ///     ],
    ///     "PrintGap": 1.2,
    ///     "Separation": {
    ///       "Name": null,
    ///       "SeparationSpeed": 1.6,
    ///       "SeparationDistance": 1.2,
    ///       "SeparationDelay": null
    ///     },
    ///     "PeriodicCleanings": [
    ///       {
    ///         "CleanFrequency": 2,
    ///         "CleanMode": "W"
    ///       }
    ///     ],
    ///     "Name": "RECIPE234324",
    ///     "Revision": "C",
    ///     "ExpectedCycleTime": 46.25,
    ///     "ExpectedUnitsPerWorkTransaction": 4.0,
    ///     "UnitLength": 22.46,
    ///     "UnitWidth": 19.21,
    ///     "UnitHeight": 0.85,
    ///     "MimeType": null,
    ///     "RecipeData": null
    ///   },
    ///   "Reason": "NewRevision"
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class UpdateRecipeRequest : CFXMessage
    {
        public UpdateRecipeRequest()
        {
            Overwrite = false;
        }

        /// <summary>
        /// If set to true, any existing Recipe at the Endpoint with the same name will be replaced by the Recipe
        /// provided in this request.  If set to False, the update request will not succeed if a Recipe with the same
        /// name exists at the Endpoint.
        /// </summary>
        public bool Overwrite
        {
            get;
            set;
        }

        /// <summary>
        /// The new Recipe to be sent to the Endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Recipe Recipe
        {
            get;
            set;
        }

        /// <summary>
        /// The reason for the update
        /// </summary>
        public RecipeModificationReason? Reason
        {
            get;
            set;
        }
    }
}
