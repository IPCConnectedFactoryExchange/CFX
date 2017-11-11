using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials
{
    public class MaterialLowWarning : CFXMessage
    {
        public Material LowMaterial
        {
            get;
            set;
        }
    }
}
