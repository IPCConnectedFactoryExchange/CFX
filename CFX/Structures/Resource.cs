using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the details of a particular Resource.
    /// This is a dynamic structure.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Resource
    {
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Default constructor
        /// </summary>
        public Resource()
        {

        }

        /// <summary>
        /// The barcode, RFID, or other unique identifier that is used to identify this machine / resource.
        /// </summary>
        [JsonProperty(Order = -3)]
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the resource to be used in GUIs or reporting (optional)
        /// </summary>
        [JsonProperty(Order = -2)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The type of resource (e.g. SMT, AOI, Oven). 
        /// </summary>
        [JsonProperty(Order = -2)]
        public string ResourceType
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the vendor of the machine / resource (optional)
        /// </summary>
        [JsonProperty(Order = -2)]
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The model number of the machine / resource
        /// </summary>
        [JsonProperty(Order = -2)]
        public string ModelNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The serial number of the machine / resource
        /// </summary>
        [JsonProperty(Order = -2)]
        public string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The software version of the machine / resource
        /// </summary>
        [JsonProperty(Order = -2)]
        public string SoftwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The firmware version of the  machine / resource (optional)
        /// </summary>
        [JsonProperty(Order = -2)]
        public string FirmwareVersion
        {
            get;
            set;
        }
    }
}