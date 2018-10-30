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
    ///   "TransactionId": "8d152f92-425d-4b5e-8c8a-da6a00f93c1b",
    ///   "UninstalledMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityUninstalled": 3.0,
    ///       "Reason": "DefectiveMaterial",
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityUninstalled": 3.0,
    ///       "Reason": "DefectiveMaterial",
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "UninstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-10T08:34:40.1054186-04:00"
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
