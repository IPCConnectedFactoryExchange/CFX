using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Used to request the name of the recipe that is activated at a process
    /// endpoint. The response indicates the name of the recipe.
    /// <code language="none">
    /// {
    ///   "ActiveRecipeName": "RECIPE5566",
    ///   "ActiveRecipeRevision": "C",
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class GetActiveRecipeResponse : CFXMessage
    {
        public GetActiveRecipeResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The name of the active recipe
        /// </summary>
        public string ActiveRecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0”
        /// </summary>
        public string ActiveRecipeRevision
        {
            get;
            set;
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
    }
}
