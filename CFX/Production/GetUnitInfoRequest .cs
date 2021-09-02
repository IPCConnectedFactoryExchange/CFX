using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// This message is used to request a process endpoint for the details of a list of Unit
    /// <code language="none">
    /// {
    ///   "PrimaryIdentifier": SN1234567890,
    ///   "HermesIdentifier": null,
    ///   "UnitIdentifier":null
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class GetUnitInfoRequest : CFXMessage
    {
        /// <summary>
        /// The barcode, RFID, etc. that was most recently acquired by the scanner / reader.  If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes BoardId (GUID) of the carrier, a PCB panel or single production unit – 
        /// optional, may be used when PrimaryIdentifier is not available.
        /// </summary>
        public string HermesIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// Unique ID of Production Unit, e.g. Barcode, to be used in case 
        /// the Primary Identifier is not available and, thus, PrimaryIdentifier is left empty.
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }
    }
}
