using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the details of a particular Endpoint that is participating in a CFX network.
    /// This is a dynamic structure.
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Endpoint() : base()
        {
            CFXVersion = CFXEnvelope.CFXVERSION;
            SupportedTopics = new List<SupportedTopic>();
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
        /// The version of CFX supported / utilized by this endpoint
        /// </summary>
        public string CFXVersion
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
        /// Contains information related to the Endpoint's support for the Hermes standard.
        /// If null, the Endpoint does not support Hermes.
        /// </summary>
        public HermesInformation HermesInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the operating requirements (environmental, etc.) of a given endpoint.
        /// May be null if not applicable.
        /// </summary>
        public OperatingRequirements OperatingRequirements
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the <see cref="CFX.Structures.SupportedTopic"/>s structures describing the level of support for this endpoint
        /// </summary>
        public List<SupportedTopic> SupportedTopics
        {
            get;
            set;
        }
    }
}
