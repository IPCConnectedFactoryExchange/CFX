using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Response to an external source to modify a generic configuration parameter of a process endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "ActiveFaults": [
    ///     {
    ///       "Cause": "MechanicalFailure",
    ///       "Severity": "Error",
    ///       "FaultCode": "ERROR 3943480",
    ///       "FaultOccurrenceId": "85a0286a-622f-4f87-99d5-1f11c95806f3",
    ///       "Lane": null,
    ///       "Stage": null,
    ///       "SideLocation": "Right",
    ///       "AccessType": "Remote",
    ///       "Description": "PCB Transport is blocked",
    ///       "DescriptionTranslations": {
    ///         "de-DE": "Der Leiterplattentransport ist blockiert"
    ///       },
    ///       "OccurredAt": "2018-10-31T15:13:30.9146011-04:00",
    ///       "DueDateTime": "2018-10-31T18:13:30.9146011-04:00"
    ///     },
    ///     {
    ///       "Cause": "LoadError",
    ///       "Severity": "Error",
    ///       "FaultCode": "ERROR 3943555",
    ///       "FaultOccurrenceId": "bb1933c4-5c7f-4840-9261-72998d682b2f",
    ///       "Lane": null,
    ///       "Stage": null,
    ///       "SideLocation": "Right",
    ///       "AccessType": "Local",
    ///       "Description": "PCB Transport is blocked",
    ///       "DescriptionTranslations": {
    ///         "de-DE": "Der Leiterplattentransport ist blockiert"
    ///       },
    ///       "OccurredAt": "2018-10-31T15:13:30.9146011-04:00",
    ///       "DueDateTime": "2018-10-31T18:13:30.9146011-04:00"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class GetActiveFaultsResponse : CFXMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveFaultsResponse"/> class.
        /// </summary>
        public GetActiveFaultsResponse()
        {
            Result = new RequestResult();
            ActiveFaults = new List<Fault>();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// A list of faults that are currently active at the endpoint
        /// </summary>
        public List<Fault> ActiveFaults
        {
            get;
            set;
        }
    }
}
