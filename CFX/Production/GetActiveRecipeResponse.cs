using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    public class GetActiveRecipeResponse : CFXMessage
    {
        public GetActiveRecipeResponse()
        {
            Result = new RequestResult();
        }

        public string ActiveRecipeName
        {
            get;
            set;
        }

        public string ActiveRecipeRevision
        {
            get;
            set;
        }

        public RequestResult Result
        {
            get;
            set;
        }
    }
}
