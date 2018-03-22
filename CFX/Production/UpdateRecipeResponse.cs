using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to send a named recipe to a process endpoint. The message
    /// includes details of the recipe, depending on the classification of the process. 
    /// The response indicates whether the recipe has been received correctly or not.
    /// </summary>
    public class UpdateRecipeResponse : CFXMessage
    {
        public UpdateRecipeResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            private set;
        }
    }
}
