using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by an endpoint when maintenance has been performed.
    /// Information includes the type of maintenance, maintenance code, parts used, labor etc.
    /// <code language="none">
    /// {
    ///   "MaintenanceType": "Preventive",
    ///   "MaintenanceOrderNumber": "MO676578576",
    ///   "MaintenanceJobCode": "MNT113334",
    ///   "ConsumedMaterials": [
    ///     {
    ///       "MaterialLocation": {
    ///         "LocationIdentifier": null,
    ///         "LocationName": null,
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": null,
    ///           "InternalPartNumber": "PN2343243",
    ///           "Quantity": 0.0
    ///         },
    ///         "CarrierInformation": null
    ///       },
    ///       "QuantityUsed": 3.0,
    ///       "QuantitySpoiled": 0.0,
    ///       "RemainingQuantity": 0.0
    ///     },
    ///     {
    ///       "MaterialLocation": {
    ///         "LocationIdentifier": null,
    ///         "LocationName": null,
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": "UID23849854385",
    ///           "InternalPartNumber": "PN4452",
    ///           "Quantity": 0.0
    ///         },
    ///         "CarrierInformation": null
    ///       },
    ///       "QuantityUsed": 3.0,
    ///       "QuantitySpoiled": 0.0,
    ///       "RemainingQuantity": 0.0
    ///     }
    ///   ],
    ///   "Tasks": [
    ///     {
    ///       "Task": "Changed hydraulic fluid in resovoir 1",
    ///       "TaskId": "HYD233432432",
    ///       "Operator": {
    ///         "OperatorIdentifier": "BADGE489435",
    ///         "ActorType": "Human",
    ///         "LastName": "Smith",
    ///         "FirstName": "Joseph",
    ///         "LoginName": "joseph.smith@abcdrepairs.com"
    ///       },
    ///       "ManHoursConsumed": 0.75
    ///     },
    ///     {
    ///       "Task": "Checked torque on main mount bolts",
    ///       "TaskId": "CHK3432434",
    ///       "Operator": {
    ///         "OperatorIdentifier": "BADGE489435",
    ///         "ActorType": "Human",
    ///         "LastName": "Smith",
    ///         "FirstName": "Joseph",
    ///         "LoginName": "joseph.smith@abcdrepairs.com"
    ///       },
    ///       "ManHoursConsumed": 0.25
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaintenancePerformed : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaintenancePerformed()
        {
            ConsumedMaterials = new List<ConsumedMaterial>();
            Tasks = new List<MaintenanceTask>();
        }

        /// <summary>
        /// An enumeration describing the type of maintenance that was performed
        /// </summary>
        public MaintenanceType MaintenanceType
        {
            get;
            set;
        }

        /// <summary>
        /// The work order number related to this maintenance event
        /// </summary>
        public string MaintenanceOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An endpoint-specific code indicating the nature of the maintenance
        /// event that was conducted
        /// </summary>
        public string MaintenanceJobCode
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific parts and materials that were consumed while performing
        /// the maintenance event
        /// </summary>
        public List<ConsumedMaterial> ConsumedMaterials
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific tasks that were performed while conducting this maintenance
        /// event
        /// </summary>
        public List<MaintenanceTask> Tasks
        {
            get;
            set;
        }
    }
}
