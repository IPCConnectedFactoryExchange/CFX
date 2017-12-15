using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Management
{
    public class MaterialsConsumed : CFXMessage
    {
        public MaterialsConsumed()
        {
            ConsumedMaterials = new List<ConsumedMaterial>();
        }

        public List<ConsumedMaterial> ConsumedMaterials
        {
            get;
            set;
        }
    }
}
