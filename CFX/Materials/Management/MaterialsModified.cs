using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    public class MaterialsModified : CFXMessage
    {
        public MaterialsModified()
        {
            Materials = new List<MaterialPackageDetail>();
        }

        public MaterialModifyReason Reason
        {
            get;
            set;
        }

        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
