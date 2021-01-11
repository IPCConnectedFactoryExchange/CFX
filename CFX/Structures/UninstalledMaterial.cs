using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes when single lot of material that is uninstalled from a production unit, 
    /// possibly from specific locations on the production unit.
    /// </summary>
    public class UninstalledMaterial
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UninstalledMaterial()
        {
            UninstalledComponents = new List<InstalledComponent>();
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6). 
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The total quantity of parts or material uninstalled of this particular MaterialPackage (lot)
        /// </summary>
        public double QuantityUninstalled
        {
            get;
            set;
        }

        /// <summary>
        /// The reason why the material was uninstalled.
        /// </summary>
        public UninstalledReason Reason
        {
            get;
            set;
        }

        /// <summary>
        /// The material package that was uninstalled (if known)
        /// </summary>
        public MaterialPackage Material
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the components that were uninstalled
        /// </summary>
        public List<InstalledComponent> UninstalledComponents
        {
            get;
            set;
        }
    }
}
