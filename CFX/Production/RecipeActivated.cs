using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class RecipeActivated : CFXMessage
    {
        public string RecipeName
        {
            get;
            set;
        }

        public string Revision
        {
            get;
            set;
        }

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
