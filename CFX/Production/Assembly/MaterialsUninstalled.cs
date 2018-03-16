using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    public class MaterialsUninstalled : CFXMessage
    {
        public MaterialsUninstalled()
        {
            InstalledMaterials = new List<UninstalledMaterial>();
        }

        public Guid TransactionId
        {
            get;
            set;
        }

        public List<UninstalledMaterial> InstalledMaterials
        {
            get;
            set;
        }
    }
}
