using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when one or more materials (see note) are installed on to a production unit. 
    /// This message is typically sent at the completion of production on a unit or group of units at the
    /// endpoint, or, at the end of each stage.
    /// <code language="none">
    /// {
    ///   "TransactionId": "7e712504-4d65-499f-9dcb-1974e20bae59",
    ///   "InstalledMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityInstalled": 3.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": {
    ///         "LocationIdentifier": "UID384234893",
    ///         "LocationName": "SLOT45",
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "123334",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "Width": "Tape8mm",
    ///           "Pitch": "Adjustable",
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334"
    ///         }
    ///       },
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityInstalled": 3.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": {
    ///         "LocationIdentifier": "UID384234893",
    ///         "LocationName": "SLOT45",
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "123334",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "Width": "Tape8mm",
    ///           "Pitch": "Adjustable",
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334"
    ///         }
    ///       },
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-03-29T08:29:20.6197528-04:00"
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsInstalled : CFXMessage
    {
        public MaterialsInstalled()
        {
            InstalledMaterials = new List<InstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific materials which were installed.
        /// </summary>
        public List<InstalledMaterial> InstalledMaterials
        {
            get;
            set;
        }
    }
}
