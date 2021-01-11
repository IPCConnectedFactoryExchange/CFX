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
    ///   "TransactionId": "ce1cf002-50fe-4cd4-af27-5e46fdae5608",
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
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 8.0,
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334"
    ///         }
    ///       },
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
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
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 8.0,
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334"
    ///         }
    ///       },
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-03T16:03:05.1091909-04:00"
    ///         }
    ///       ],
    ///       "NonInstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "NonInstallationTime": "2018-10-03T16:03:05.1091909-04:00",
    ///           "Location" : "RejectionBox",
    ///           "RejectionBoxId" : "RejectionBox1",
    ///           "RejectionComment" : "Bad electrical test measure",
    ///           "RejectionReason": "BadElectricalTest",
    ///           "RejectionDetails": {
    ///             "$type": "CFX.Structures.BadElectricalTestRejectionDetails, CFX",
    ///             "TesterSerialNumber" : "ELECTRICAL-TESTER-0123456789"
    ///             "Frequency": "1000"
    ///             "ExpectedValue": "3300",
    ///             "MeasuredValue": "3100",
    ///             "ToleranceMin": "100",
    ///             "ToleranceMax": "100",
    ///             "ValueUnit": "Ohm",
    ///             "result": "false",
    ///           }
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsInstalled : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
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
