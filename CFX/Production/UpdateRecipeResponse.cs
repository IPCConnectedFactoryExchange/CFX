using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
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
