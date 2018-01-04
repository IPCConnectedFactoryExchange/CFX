using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.Assembly
{
    public class MaterialsInstalled : CFXMessage
    {
        public MaterialsInstalled()
        {
            InstalledMaterials = new List<InstalledMaterial>();
        }

        public List<InstalledMaterial> InstalledMaterials
        {
            get;
            set;
        }
    }
}
