using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class MaterialPackage
    {
        public MaterialPackage()
        {
        }

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string InternalPartNumber
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }
    }
}
