using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials
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
            protected set;
        }
    }
}
