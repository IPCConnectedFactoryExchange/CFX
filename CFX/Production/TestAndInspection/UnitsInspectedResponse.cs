using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// Sent from a process endpoint in order to validate the submission of the test result of an unit.  
    /// Process endpoints, where configured, should send this request before allowing the unit to leave
    /// the current process.
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
    ///   "TestValidationResults": [
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
    public class UnitsInspectedResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitsInspectedResponse()
        {
            Result = new RequestResult();
            PrimaryResult = new TestValidationResult();
            TestValidationResults = new List<TestValidationResult>();
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
        /// Overall result of the test validation request
        /// </summary>
        public TestValidationResult PrimaryResult
        {
            get;
            set;
        }

        /// <summary>
        /// Individual results of the test validation request (for multiple units in a carrier or PCB Panel)
        /// </summary>
        public List<TestValidationResult> TestValidationResults
        {
            get;
            set;
        }
    }
}
