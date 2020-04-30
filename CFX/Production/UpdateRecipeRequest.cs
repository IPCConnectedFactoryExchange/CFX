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
    ///     "MimeType": "application/octet-stream",
    ///     "RecipeData": "//w0"
    ///   },
    ///   "Reason": "NewRevision"
    /// }
    /// </code>
    /// <para>Load Printer Recipe / Modify Printer Recipe based on UpdateRecipeRequest and UpdateRecipeResponse </para>
    /// <code>
    /// {
    ///   "Overwrite": true,
    ///   "Recipe": {
    ///     "Name": "RECIPE234324",
    ///     "Revision": "C",
    ///     "ExpectedCycleTime": 0.0,
    ///     "ExpectedUnitsPerWorkTransaction": 0.0,
    ///     "MimeType": null,
    ///     "RecipeData": null
    ///   },
    ///   "Reason": "NewRevision",
    ///   "CommonRecipeData": {
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
    ///     "PrintGap": 1.3,
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
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
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
        /// <summary>
        /// Dynamic structure containing data that is common to all production units processed
        /// within this Recipe. New for CFX 1.2, Printer management
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public ProcessData CommonRecipeData
        {
            get;
            set;
        }
    }
}
