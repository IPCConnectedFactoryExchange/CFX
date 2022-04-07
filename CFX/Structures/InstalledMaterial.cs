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
        /// <summary>
        /// Default constructor
        /// </summary>
        public InstalledMaterial()
        {
            InstalledComponents = new List<InstalledComponent>();
            NonInstalledComponents = new List<NonInstalledComponent>();
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
        /// <para>** NOTE: ADDED in CFX 1.4 **</para>
        /// The total quantity of parts or material non installed of this particular MaterialPackage (lot)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.4")]
        public double QuantityNonInstalled
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
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<InstalledComponent> InstalledComponents
        {
            get;
            set;
        }
		
		/// <summary>
        /// A list of where the on the production unit the materials / parts were not installed.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<NonInstalledComponent> NonInstalledComponents
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// If the material package is used as an alternate part, this parameter indicates the original part number.
        /// For example, if A0805-001 was supposed to be used but A0805-002 was used instead (because A0805-001 was missing for example),
        /// the internal part number of the material package will be A0805-002, and the referecne part number will be A0805-001.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        public string ReferencePartNumber
        {
            get;
            set;
        }
    }
}
