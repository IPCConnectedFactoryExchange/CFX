using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class GetRecipeRequest : CFXMessage
    {
        public string RecipeName
        {
            get;
            set;
        }
    }
}
