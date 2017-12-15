using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    public class MaterialsUnloaded : CFXMessage
    {
        public MaterialsUnloaded()
        {
            MaterialPackageIdentifiers = new List<string>();
        }

        /// <summary>
        /// List of material packages to be unloaded.  
        /// </summary>
        public List<string> MaterialPackageIdentifiers
        {
            get;
            set;
        }
    }
}
