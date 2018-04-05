using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when one or more materials (see note) are removed from a production unit.
    /// This message is typically sent at the completion of a production unit or group of units at the
    /// endpoint, or, at the end of each stage.
    /// <code language="none">
    /// {
    ///   "TransactionId": "9ad7e32d-b1ac-4813-b0e4-28d20b9aefba",
    ///   "UninstalledMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityUninstalled": 3.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityUninstalled": 3.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-03-29T08:29:20.6413886-04:00"
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsUninstalled : CFXMessage
    {
        public MaterialsUninstalled()
        {
            UninstalledMaterials = new List<UninstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this uninstallation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of materials which have been uninstalled.
        /// </summary>
        public List<UninstalledMaterial> UninstalledMaterials
        {
            get;
            set;
        }
    }
}
