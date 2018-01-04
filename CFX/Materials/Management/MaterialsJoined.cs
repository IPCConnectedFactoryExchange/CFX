using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    public class MaterialsJoined : CFXMessage
    {
        public MaterialPackage LeadingMaterialPackage
        {
            get;
            set;
        }

        public MaterialPackage TrailingMaterialPackage
        {
            get;
            set;
        }
    }
}
