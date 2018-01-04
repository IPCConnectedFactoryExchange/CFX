using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    public class MaterialsInitialized : CFXMessage
    {
        public MaterialsInitialized()
        {
            Materials = new List<MaterialPackageDetail>();
        }

        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
