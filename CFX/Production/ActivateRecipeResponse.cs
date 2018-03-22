using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    /// <summary>
    /// Used to activate a named recipe at the process endpoint. 
    /// The response indicates whether this was successful or not.
    /// </summary>
    public class ActivateRecipeResponse : CFXMessage
    {
        public ActivateRecipeResponse()
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
    }
}
