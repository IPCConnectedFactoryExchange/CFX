using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Response to a request of getting the available recipes. 
    /// The response includes a list of recipes (name, revision), but not their data.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "ActualCount": 3,
    ///   "RecipeCount": 2,
    ///   "Recipes": [
    ///     {
    ///       "RecipeName": "Recipe1",
    ///       "Revision": "1.2"
    ///     },
    ///     {
    ///       "RecipeName": "Recipe2",
    ///       "Revision": "2.7"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetAvailableRecipesResponse : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GetAvailableRecipesResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
        /// <summary>
        /// The actual number of recipes that match the request.
        /// </summary>
        public int ActualCount
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int RecipeCount
        {
            get
            {
                return Recipes != null ? Recipes.Count : 0;
            }
            private set
            {
            }
        }

        /// <summary>
        /// An optional list of the identified RecipeLean (RecipeName and Revision) structures 
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<RecipeLean> Recipes
        {
            get;
            set;
        }
    }
}
