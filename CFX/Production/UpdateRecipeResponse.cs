using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class UpdateRecipeResponse
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
