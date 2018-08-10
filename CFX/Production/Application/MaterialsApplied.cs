using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.Production.Application
{
    /// <summary>
    /// Sent when material is applied to a production unit, such as glue, adhesives, coatings, solder, paste, etc.
    /// <code language="none">
    /// {
    ///   "TransactionId": "ce68a27a-af0b-42c2-a4b3-1066196a9f4a",
    ///   "AppliedMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityInstalled": 3.57,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": []
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityInstalled": 3.45,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": []
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsApplied : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialsApplied()
        {
            AppliedMaterials = new List<InstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this message is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific materials which were applied.
        /// </summary>
        public List<InstalledMaterial> AppliedMaterials
        {
            get;
            set;
        }
    }
}
