using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderingStation.Identification;
using Newtonsoft.Json;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to request the capabilities of a specified single endpoint. The response
    /// includes information about the endpoint, including its CFX Handle, and network hostname / address.
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Generic example:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": 
    ///   {
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetSolderingStationsHostInformationResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetSolderingStationsHostInformationResponse() : base()
        {
            Result = new RequestResult();
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
        /// Dynamic structure that describes the details of this endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public SolderingStationsHostPC EndpointInformation
        {
            get;
            set;
        }
    }
}
