using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    public class GetEndpointInformationResponse : CFXMessage
    {
        public GetEndpointInformationResponse()
        {
            Result = new RequestResult();
            SupportedTopics = new List<SupportedTopic>();
        }

        public RequestResult Result
        {
            get;
            set;
        }

        public string CFXHandle
        {
            get;
            set;
        }

        public string RequestNetworkUri
        {
            get;
            set;
        }

        /// <summary>
        /// Optional field if a single network host is servicing multiple endpoints.  For AMQP, corresponds to the AMQP 1.0 target address.
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

        public string FriendlyName
        {
            get;
            set;
        }

        public string Vendor
        {
            get;
            set;
        }

        public string ModelNumber
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public List<SupportedTopic> SupportedTopics
        {
            get;
            set;
        }
    }
}
