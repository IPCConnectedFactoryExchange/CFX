using System;
using System.Collections.Generic;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Sent by a process endpoint to indicate the activation of a recipe by its name
    /// <code language="none">
    /// {
    ///   "TransactionID": null,
    ///   "Lane": 1,
    ///   "Stage": null,
    ///   "ProductionChanges”: [
    ///   {
    ///     "$type": "CFX.Structures.ComponentRemovalLocalRecipeChange, CFX",
    ///     "Type": 1,
    ///     "State": 0,
    ///     "Designator": {
    ///         "ReferenceDesignator": "R01"
    ///         "UnitPosition": 2
    ///         "PartNumber": "PN0123"
    ///     }
    ///   },
    ///   {
    ///     "$type": "CFX.Structures.ComponentRemovalLocalRecipeChange, CFX",
    ///     "Type": 1,
    ///     "State": 0,
    ///     "Designator": {
    ///         "ReferenceDesignator": "R05"
    ///         "UnitPosition": 2
    ///         "PartNumber": "PN0456"
    ///     }
    ///   }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class LocalRecipeChanged : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public LocalRecipeChanged()
        {
            LocalRecipeChanges = new List<LocalRecipeChange>();
        }

        /// <summary>
        /// Optional TransactionID if the changes only concern a particular work. If null, the message applies to all the current and future Works.
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// Number of the production lane where the recipe is activated (if applicable).
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The optional stage where the recipe is activated. Null if the recipe is activated on the whole endpoint.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The list of local changes
        /// This is a dynamic structure.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<LocalRecipeChange> LocalRecipeChanges
        {
            get;
            set;
        }
    }
}
