using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class MaterialLocation
    {
        public MaterialLocation()
        {
            Location = "";
        }

        public Material Material
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }
    }
}
