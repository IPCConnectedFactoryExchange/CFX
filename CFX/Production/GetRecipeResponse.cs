using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class GetRecipeResponse
    {
        public GetRecipeResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            private set;
        }

        public Recipe Recipe
        {
            get;
            set;
        }
    }
}
