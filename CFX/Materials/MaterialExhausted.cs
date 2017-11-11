using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials
{
    public class MaterialExhausted : CFXMessage
    {
        public Material ExhaustedMaterial
        {
            get;
            set;
        }
    }
}
