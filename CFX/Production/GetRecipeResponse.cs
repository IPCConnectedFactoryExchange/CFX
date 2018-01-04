using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    public class GetRecipeResponse : CFXMessage
    {
        public GetRecipeResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            set;
        }

        public Recipe Recipe
        {
            get;
            set;
        }
    }
}
