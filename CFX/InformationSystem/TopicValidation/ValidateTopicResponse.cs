using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.InformationSystem.TopicValidation
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Response to a request that a specific topic (e.g., tool, material carrier, recipe, material) was successfull validated or not.
    ///Example 1: Tools
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Tools",
    ///   "Result": [
    ///     {
    ///       "Result": "Success",
    ///       "ResultCode": 0,
    ///       "Message": "Ok"
    ///     },
    ///     {
    ///       "Result": "Failed",
    ///       "ResultCode": 99,
    ///       "Message": "Not Ok"
    ///     }
    ///   ]
    /// }
    /// </code>
    ///Example 2: Materials
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Materials",
    ///   "Result": [
    ///     {
    ///       "Result": "Success",
    ///       "ResultCode": 0,
    ///       "Message": "Ok"
    ///     },
    ///     {
    ///       "Result": "Failed",
    ///       "ResultCode": 99,
    ///       "Message": "Not Ok"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// Example 3: MaterialCarrier
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "MaterialCarrier",
    ///   "Result": [
    ///     {
    ///       "Result": "Failed",
    ///       "ResultCode": 301,
    ///       "Message": "Not Ok"
    ///     },
    ///     {
    ///       "Result": "Warning",
    ///       "ResultCode": 10,
    ///       "Message": "Check the material carrier"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// Example 4: Recipe
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Recipe",
    ///   "Result": [
    ///     {
    ///       "Result": "Success",
    ///       "ResultCode": 0,
    ///       "Message": "Ok"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class ValidateTopicResponse : CFXMessage
    {
        /// <summary>
        /// An enum for the specific validation topic of the request.
        /// </summary>
        public ValidationTopic ValidationTopic
        {
            get;
            set;
        }
        /// <summary>
        /// The result of the request
        /// </summary>
        public List<RequestResult> Result
        {
            get;
            set;
        }
    }
}
