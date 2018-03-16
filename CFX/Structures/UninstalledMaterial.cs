using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    public class UninstalledMaterial
    {
        public UninstalledMaterial()
        {
            UninstalledComponents = new List<InstalledComponent>();
        }

        public string UnitIdentifier
        {
            get;
            set;
        }

        public int? UnitPositionNumber
        {
            get;
            set;
        }

        public double QuantityUninstalled
        {
            get;
            set;
        }

        public MaterialPackage Material
        {
            get;
            set;
        }

        public List<InstalledComponent> UninstalledComponents
        {
            get;
            set;
        }
    }
}
