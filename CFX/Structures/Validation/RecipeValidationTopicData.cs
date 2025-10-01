using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Validation
{
    /// <summary>
    /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
    /// Represents the information of a recipe that needs to be validated 
    /// by <see cref="InformationSystem.TopicValidation.ValidateTopicRequest"/>.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    [CFX.Utilities.CreatedVersion("2.0")]
    public class RecipeValidationTopicData : ValidationData
    {
        /// <summary>
        /// The name of the recipe (may include full path, if applicable)
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// An optional version number, e.g. “2.0”
        /// </summary>
        public string Revision
        {
            get;
            set;
        }
        /// <summary>
        /// The optional number of the production lane where 
        /// the recipe should be activated
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }
        /// <summary>
        /// A structure describing basic information about the stage.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
