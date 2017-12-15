using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Management.MSDManagement
{
    public class MaterialsPlacedInDryStorage : CFXMessage
    {
        public MaterialsPlacedInDryStorage()
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
