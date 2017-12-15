using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Management
{
    public class MaterialsSplit : CFXMessage
    {
        public MaterialPackage OriginalMaterialPackage
        {
            get;
            set;
        }

        public MaterialPackage NewMaterialPackage
        {
            get;
            set;
        }
    }
}
