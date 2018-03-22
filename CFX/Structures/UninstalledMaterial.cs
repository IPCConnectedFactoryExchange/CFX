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
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard).
        /// Position information is only required where the endpoint is unaware of each production
        /// unit’s true unique identifier.  
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
