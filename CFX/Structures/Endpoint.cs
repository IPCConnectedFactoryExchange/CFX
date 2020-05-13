﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the details of a particular Endpoint that is participating in a CFX network.
    /// This is a dynamic structure.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Endpoint
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Endpoint() : base()
        {
            CFXVersion = CFXEnvelope.CFXVERSION;
            SupportedTopics = new List<SupportedTopic>();
            Stages = new List<StageInformation>();
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
        /// The software version of the endpoint
        /// </summary>
        public string SoftwareVersion
        {
            get;
            set;
        }
        
        /// <summary>
        /// The firmware version of the endpoint
        /// </summary>
        public string FirmwareVersion
        {
            get;
            set;
        }        
        
        /// <summary>
        /// Describes the stages (zones) of the endpoint, including buffer stages.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<StageInformation> Stages
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
        
        public enum OperatingSystem
        {
    	    /// <summary>
    	    /// Unknown Operating System
    	    /// </summary>    
    	    Unknown
            /// <summary>
            /// Windows 7 32-bit
            /// </summary>
            Windows7_32,
            /// <summary>
            /// Windows 7 64-bit
            /// </summary>
            Windows7_64,
            /// <summary>
            /// Windows 8 32-bit
            /// </summary>
            Windows8_32,
            /// <summary>
            /// Windows 8 64-bit
            /// </summary>
            Windows8_64,
            /// <summary>
            /// Windows 10 32-bit
            /// </summary>
            Windows10_32,
            /// <summary>
            /// Windows 10 64-bit
            /// </summary>
            Windows10_64,
            /// <summary>
            /// Windows Server 2008
            /// </summary>
            WindowsServer2008,
            /// <summary>
            /// Windows Server 2012
            /// </summary>
            WindowsServer2012,
            /// <summary>
            /// Windows Server 2016
            /// </summary>
            WindowsServer2016,                             
            /// <summary>
            /// Linux
            /// </summary>
            Linux,         
        }
    }
}
