using System;
using System.Collections.Generic;
using System.Text;
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
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "PrimaryResult": {
    ///     "UniqueIdentifier": "CARRIER5566",
    ///     "PositionNumber": 0,
    ///     "Result": "Passed",
    ///     "FailureCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "Results": [
    ///     {
    ///       "UniqueIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "Result": "Passed",
    ///       "FailureCode": 0,
    ///       "Message": "OK"
    ///     },
    ///     {
    ///       "UniqueIdentifier": "CARRIER5566",
    ///       "PositionNumber": 2,
    ///       "Result": "Passed",
    ///       "FailureCode": 0,
    ///       "Message": "OK"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class ValidateUnitsResponse : CFXMessage
    {
        public ValidateUnitsResponse()
        {
            Result = new RequestResult();
            PrimaryResult = new ValidationResult();
            Results = new List<ValidationResult>();
        }

        /// <summary>
        /// Result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// Overall result of the validation request
        /// </summary>
        public ValidationResult PrimaryResult
        {
            get;
            set;
        }

        /// <summary>
        /// Individual results of the validation request (for multiple units in a carrier or PCB Panel)
        /// </summary>
        public List<ValidationResult> Results
        {
            get;
            set;
        }
    }
}
