using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class ConsumedMaterial
    {
        public ConsumedMaterial()
        {
        }

        public Material Material
        {
            get;
            set;
        }

        public double QuantityConsumed
        {
            get;
            set;
        }

        public double RemainingQuantity
        {
            get;
            set;
        }
    }
}
