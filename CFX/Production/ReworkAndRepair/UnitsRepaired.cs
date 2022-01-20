using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.ReworkAndRepair
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Sent by a process endpoint when one or more units have been reworked or repaird.  Includes outcome information,
    /// as well as a detailed report of the repair(s) performed.  If defects or faulty test results (symptoms) were
    /// previously reported for these production unit(s), this message also relates the repairs performed back to these
    /// inspection/test results.
    /// <para>  </para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "080ff333-2577-45e4-8440-3ef38bb79945",
    ///   "RepairOperator": {
    ///     "OperatorIdentifier": "BADGE489499",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Joseph",
    ///     "LoginName": "joseph.smith@abcdrepairs.com"
    ///   },
    ///   "RepairedUnits": [
    ///     {
    ///       "UnitIdentifier": "FFSHkkskamJDHS",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "RepairSuccessful",
    ///       "Repairs": [
    ///         {
    ///           "UniqueIdentifier": "a604ed78-c314-48ab-b963-8111bf4d85ef",
    ///           "RepairName": "Joint Repair",
    ///           "RepairStartTime": "2021-06-23T15:39:23.0062167-04:00",
    ///           "RepairEndTime": "2021-06-23T15:40:03.0062167-04:00",
    ///           "Comments": "Repaired cold solder joint at U34, Pin 5",
    ///           "ComponentOfInterest": {
    ///             "ReferenceDesignator": "U34.5",
    ///             "UnitPosition": null,
    ///             "PartNumber": "SN74HCS30DR"
    ///           },
    ///           "RegionOfInterest": null,
    ///           "RelatedDefectIdentifiers": [
    ///             "b1031227-d911-4be2-ba74-7a3fe019e5fa"
    ///           ],
    ///           "ReclassifiedDefects": [],
    ///           "RelatedSymptomIdentifiers": [],
    ///           "ReclassifiedSymptoms": [],
    ///           "Result": "RepairSuccessful",
    ///           "Error": null
    ///         },
    ///         {
    ///           "UniqueIdentifier": "d9a6639d-2312-4f97-8494-e8adfdae19b3",
    ///           "RepairName": "Joint Repair",
    ///           "RepairStartTime": "2021-06-23T15:39:23.0062167-04:00",
    ///           "RepairEndTime": "2021-06-23T15:40:03.0062167-04:00",
    ///           "Comments": "Repaired solder bridge at U24, Pins 4-5",
    ///           "ComponentOfInterest": {
    ///             "ReferenceDesignator": "U24.4-5",
    ///             "UnitPosition": null,
    ///             "PartNumber": "SN74HCS50DR"
    ///           },
    ///           "RegionOfInterest": null,
    ///           "RelatedDefectIdentifiers": [
    ///             "e9c72d08-a0f0-450b-b5f4-49145edfca6b"
    ///           ],
    ///           "ReclassifiedDefects": [],
    ///           "RelatedSymptomIdentifiers": [],
    ///           "ReclassifiedSymptoms": [],
    ///           "Result": "RepairSuccessful",
    ///           "Error": null
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class UnitsRepaired : CFXMessage
    {
        ///<summary>
        /// Unit inspected default constructor, used to model all the different inspection options
        /// </summary>
        public UnitsRepaired()
        {
            RepairedUnits = new List<RepairedUnit>();
            RepairOperator = new Operator();
        }

        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the repair(s), or operator of the automated equipment that performed the repairs (optional)
        /// </summary>
        public Operator RepairOperator
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were repaired, along with the details of those repairs, 
        /// and the results.
        /// </summary>
        public List<RepairedUnit> RepairedUnits
        {
            get;
            set;
        }
    }
}
