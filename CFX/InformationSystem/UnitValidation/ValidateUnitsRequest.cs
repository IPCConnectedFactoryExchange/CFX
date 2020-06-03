using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;
using CFX.Structures;

namespace CFX.InformationSystem.UnitValidation
{
    /// <summary>
    /// Sent from a process endpoint in order to validate the identifier of the next production unit.  
    /// Process endpoints, where configured, should send this request before allowing the next unit
    /// to enter the process. Configuration must be provided to identify the endpoint that implements 
    /// CFX.InformationSystem.UnitValidation Identification and is responsible to provide the response.
    /// <code language="none">
    /// {
    ///   "Validations": [
    ///     "UnitRouteValidation",
    ///     "UnitStatusValidation"
    ///   ],
    ///   "PrimaryIdentifier": "CARRIER2342",
    ///   "Units": [
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT1",
    ///       "X": 50.45,
    ///       "Y": 80.66,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 2,
    ///       "PositionName": "CIRCUIT2",
    ///       "X": 70.45,
    ///       "Y": 80.66,
    ///       "Rotation": 90.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class ValidateUnitsRequest : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ValidateUnitsRequest()
        {
            Validations = new List<ValidationType>();
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// List of validations to be performed”. Options are: UnitRouteValidation", "UnitStatusValidation"
        /// </summary>
        public List<ValidationType> Validations
        {
            get;
            set;
        }

        /// <summary>
        /// Identification used for the carrier (or the unit itself if no carrier)
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes BoardId of the carrier, a PCB panel or single production unit. If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// HermesIdentifier will be transfered between all machines which support Hermes. The PrimaryIdentifier is containing a barcode information.
        /// Both can be transferred.
        /// <remarks>
        /// Espcially when the line does not support the Hermes standard in the hole line, the Hermes Identifier can be unique only in the a part
        /// of the line. The Primary Identifier can be used to correlate the parts of hermes sublines to correlate this data as well. 
        /// </remarks>
        /// </summary>
        public string HermesIdentifier 
        {
            get;
            set;
        }

        /// <summary>
        /// List of structures that identify each specific instance of production unit that arrived (could be within a carrier or panel). 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.2 **</para>
        /// Lane identifier.  Null if no specific lane
        /// </summary>
        /// <remarks>
        /// This field allows distinguishing between requests when different kinds of units enter the machine and all need to be validated.
        /// For instance, a depaneling cell where both panels and carriers would need to be validated.
        /// - The panel has a data matrix for id and a set of modules whose statuses need to be validated.
        /// - The carrier (pallet, fixture, tray, etc) has a data matrix for id and a set of nests whose statuses need to be validated.
        /// </remarks>
        [CFX.Utilities.CreatedVersion("1.2")]
        public int? Lane
        {
            get;
            set;
        }
    }
}
