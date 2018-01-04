using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    class UnblockMaterialsRequest : CFXMessage
    {
        public UnblockMaterialsRequest()
        {
            Materials = new List<MaterialPackage>();
        }

        public List<MaterialPackage> Materials
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public Operator Unblocker
        {
            get;
            set;
        }
    }
}
