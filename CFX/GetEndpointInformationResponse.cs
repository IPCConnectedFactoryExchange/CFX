using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to request the capabilities of a specified single endpoint. The response
    /// sends basic information about the endpoint, including its CFX Handle, and network hostname / address.
    /// </summary>
    public class GetEndpointInformationResponse : CFXMessage
    {
        public GetEndpointInformationResponse()
        {
            Result = new RequestResult();
            SupportedTopics = new List<SupportedTopic>();
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
        /// The handle of the endpoint that is responding
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }

        /// <summary>
        /// The network address / Uri to be used for requests to this endpoint
        /// </summary>
        public string RequestNetworkUri
        {
            get;
            set;
        }

        /// <summary>
        /// The AMQP 1.0 target address to be used for requests to this endpoint
        /// </summary>
        public string RequestTargetAddress
        {
            get;
            set;
        }

        /// <summary>
        /// The barcode, RFID, or other unique identifier that is used to identify this machine / endpoint.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the endpoint to be used in GUIs or reporting
        /// </summary>
        public string FriendlyName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the vendor of the endpoint.
        /// </summary>
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The model number of the endpoint
        /// </summary>
        public string ModelNumber
        {
            get;
            set;
        }
        
        /// <summary>
        /// The serial number of the endpoint
        /// </summary>
        public string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The number of stages (zones) of the endpoint
        /// </summary>
        public int NumberOfStages
        {
            get;
            set;
        }

        /// <summary>
        /// The number of production lanes of the endpoint
        /// </summary>
        public int NumberOfLanes
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the topics that the endpoint supports
        /// </summary>
        public List<SupportedTopic> SupportedTopics
        {
            get;
            set;
        }
    }
}
