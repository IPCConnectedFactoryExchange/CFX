using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class ConsumedMaterial
    {
        public ConsumedMaterial()
        {
        }

        public MaterialLocation MaterialLocation
        {
            get;
            set;
        }

        public double QuantityUsed
        {
            get;
            set;
        }

        public double QuantitySpoiled
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
