using System;
using System.Collections.Generic;
using System.Text;
using CFX.Production.TestAndInspection;
using CFX.Structures;
using CFX.Structures.Production.TestAndInspection;

namespace CFX.Production
{
    /// <summary>
    /// Used to request the recipe base info that is activated at a process
    /// endpoint. The response indicates the description of the recipe.
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
    public class GetActiveRecipeBaseInfoResponse
    {
        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// This is the Panel describing the recipe base info 
        /// </summary>
        public Panel Panel
        {
            get;
            set;
        }

        
    }
}
