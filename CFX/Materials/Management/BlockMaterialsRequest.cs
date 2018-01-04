using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    public class BlockMaterialsRequest : CFXMessage
    {
        public BlockMaterialsRequest()
        {
            MaterialPackageIdentifiers = new List<string>();
            Blocker = new Operator();
        }

        public List<string> MaterialPackageIdentifiers
        {
            get;
            set;
        }

        public BlockReason Reason
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public Operator Blocker
        {
            get;
            set;
        }
    }
}
