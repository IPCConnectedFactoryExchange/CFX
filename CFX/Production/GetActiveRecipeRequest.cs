using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class GetActiveRecipeRequest : CFXMessage
    {
        public string Lane
        {
            get;
            set;
        }

        public string Stage
        {
            get;
            set;
        }
    }
}
