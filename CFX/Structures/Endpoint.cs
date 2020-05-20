using System;
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
        [CFX.Utilities.CreatedVersion("1.2")]
        public string SoftwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The firmware version of the endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public string FirmwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The operating system in place at this endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public OperatingSystem OperatingSystem
        {
            get;
            set;
        }

        /// <summary>
        /// The platform of the operating system in place at this endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public OperatingSystemPlatform OperatingSystemPlatform
        {
            get;
            set;
        }

        /// <summary>
        /// The firmware version of the endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public string OperatingSystemVersion
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
    }

    /// <summary>
    /// An enumeration indicating a computer operating system
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public enum OperatingSystem
    {
        /// <summary>
        /// Other Operating System (not listed here)
        /// </summary>    
        Other,
        /// <summary>
        /// Other Embedded Operating System (not listed here)
        /// </summary>
        OtherEmbedded,
        /// <summary>
        /// Windows XP
        /// </summary>
        WindowsXP,
        /// <summary>
        /// Windows 7
        /// </summary>
        Windows7,
        /// <summary>
        /// Windows Vista
        /// </summary>
        WindowsVista,
        /// <summary>
        /// Windows 8
        /// </summary>
        Windows8,
        /// <summary>
        /// Windows 10
        /// </summary>
        Windows10,
        /// <summary>
        /// Windows Server 2008
        /// </summary>
        WindowsServer2008,
        /// <summary>
        /// Windows Server 2008 R2
        /// </summary>
        WindowsServer2008R2,
        /// <summary>
        /// Windows Server 2012
        /// </summary>
        WindowsServer2012,
        /// <summary>
        /// Windows Server 2016
        /// </summary>
        WindowsServer2016,
        /// <summary>
        /// Windows CD
        /// </summary>
        WindowsCE,
        /// <summary>
        /// Windows Embedded
        /// </summary>
        WindowsEmbedded,
        /// <summary>
        /// Windows Compact
        /// </summary>
        WindowsCompact,
        /// <summary>
        /// Windows IoT Core
        /// </summary>
        WindowsIoTCore,
        /// <summary>
        /// Ubuntu Linux Distro
        /// </summary>
        UbuntuLinux,
        /// <summary>
        /// Fedora Linux Distro
        /// </summary>
        FedoraLinux,
        /// <summary>
        /// Linux Mint Distro
        /// </summary>
        LinuxMint,
        /// <summary>
        /// openSUSE Linux Distro
        /// </summary>
        openSUSELinux,
        /// <summary>
        /// PC Linux Distro
        /// </summary>
        PCLinuxOS,
        /// <summary>
        /// Debian Linux Distro
        /// </summary>
        DebianLinux,
        /// <summary>
        /// Other Linux Distro
        /// </summary>
        OtherLinux,
        /// <summary>
        /// Apple MacOS
        /// </summary>
        AppleMacOS,
        /// <summary>
        /// Apple IOS or sub-variant
        /// </summary>
        AppleIOS,
        /// <summary>
        /// Raspberry Pi Operating System
        /// </summary>
        Raspbian
    }

    /// <summary>
    /// An enumeration indicating the platform of a computer operating system
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public enum OperatingSystemPlatform
    {
        /// <summary>
        /// Other Platform (not listed here)
        /// </summary>    
        Other,
        /// <summary>
        /// 32-bit Platform
        /// </summary>
        Platform32bit,
        /// <summary>
        /// 64-bit Platform
        /// </summary>
        Platform64bit,
        /// <summary>
        /// 32-bit ARM Platform
        /// </summary>
        ARM32,
        /// <summary>
        /// 64-bit ARM Platform
        /// </summary>
        AR64
    }
}