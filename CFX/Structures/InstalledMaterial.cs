using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a single lot of material that was installed on a production unit, possibly
    /// in specific locations on the production unit.
    /// </summary>
    public class InstalledMaterial
    {
        public InstalledMaterial()
        {
            InstalledComponents = new List<InstalledComponent>();
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
        /// unit’s true unique identifier.  
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The total quantity of parts or material installed of this particular MaterialPackage (lot)
        /// </summary>
        public double QuantityInstalled
        {
            get;
            set;
        }

        /// <summary>
        /// The material package that was installed
        /// </summary>
        public MaterialPackage Material
        {
            get;
            set;
        }

        /// <summary>
        /// Carrier and Location on the endpoint from which the material was dispensed (when applicable)
        /// </summary>
        public MaterialCarrierLocation CarrierLocation
        {
            get;
            set;
        }

        /// <summary>
        /// A list of where the on the production unit the materials / parts were installed.
        /// </summary>
        public List<InstalledComponent> InstalledComponents
        {
            get;
            set;
        }
    }
}
