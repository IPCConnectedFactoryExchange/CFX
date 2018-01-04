using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management.MSDManagement
{
    public class MaterialsExpired : CFXMessage
    {
        public MaterialsExpired()
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
