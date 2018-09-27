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
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "ActiveRecipeName": "RECIPE5566",
    ///   "ActiveRecipeRevision": "C"
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
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the active recipe (may include full path, if applicable)
        /// </summary>
        public string ActiveRecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0” (Optional)
        /// </summary>
        public string ActiveRecipeRevision
        {
            get;
            set;
        }
    }
}
