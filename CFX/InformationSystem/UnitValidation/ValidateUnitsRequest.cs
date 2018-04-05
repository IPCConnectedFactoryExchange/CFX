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
    ///       "X": 0.254,
    ///       "Y": 0.556,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT2",
    ///       "X": 6.254,
    ///       "Y": 0.556,
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
        /// List of structures that identify each specific instance of production unit that arrived (could be within a carrier or panel). 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
