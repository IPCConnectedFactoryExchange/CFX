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
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the resource to be used in GUIs or reporting (optional)
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the vendor of the machine / resource (optional)
        /// </summary>
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The model number of the machine / resource
        /// </summary>
        public string ModelNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The serial number of the machine / resource
        /// </summary>
        public string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The software version of the machine / resource
        /// </summary>
        public string SoftwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The firmware version of the  machine / resource (optional)
        /// </summary>
        public string FirmwareVersion
        {
            get;
            set;
        }
    }
}