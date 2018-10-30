using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.Production.Application
{
    /// <summary>
    /// Sent when material is unapplied or removed from a production unit, as in the case
    /// of paste being wiped clean, for example.
    /// <code language="none">
    /// {
    ///   "TransactionId": "f5f4d00c-c346-4a5b-a98c-4be22aec2d49",
    ///   "UnappliedMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityUninstalled": 3.55,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": []
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityUninstalled": 3.55,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": []
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsUnapplied : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialsUnapplied()
        {
            UnappliedMaterials = new List<UninstalledMaterial>();
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
        /// A list of materials which have been uninstalled.
        /// </summary>
        public List<UninstalledMaterial> UnappliedMaterials
        {
            get;
            set;
        }
    }
}
