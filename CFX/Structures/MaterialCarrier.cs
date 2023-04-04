using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures.SMTPlacement;

namespace CFX.Structures
{
    /// <summary>
    /// A dynamic structure which describes a device that is mounted at a process endpoint which contains
    /// source materials that are then consumed by the endpoint.  An SMD Tape Feeder would be an example of a MaterialCarrier.
    /// This base MaterialCarrier structure is used to describe a generic carrier, when a more specific carrier location class is
    /// not available, such as <see cref="SMDTapeFeeder"/>, <see cref="SMDTubeFeeder"/>, and <see cref="SMDTubeFeeder"/>.
    /// </summary>
    public class MaterialCarrier
    {
        /// <summary>
        /// The unique identifier for this carrier (barcode, RFID, etc.)
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// A human readable name for this carrier
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// An upper level carrier in which this carrier is loaded (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public MaterialCarrier ParentCarrier
        {
            get;
            set;
        }
    }

}
