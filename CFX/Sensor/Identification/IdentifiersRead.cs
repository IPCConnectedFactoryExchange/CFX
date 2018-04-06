using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Sensor.Identification
{
    /// <summary>
    /// Sent by an identification device (barcode scanner, RFID reader, etc.) when the device has identified one or more items
    /// <para>Example 1 (Simple, single barcode read)</para>
    /// <code language="none">
    /// {
    ///   "PrimaryIdentifier": "CARRIER21342",
    ///   "Units": null
    /// }
    /// </code>
    /// <para>Example 2 (Camera system capable of reading all barcodes on a multi-circuit PCB panel)</para>
    /// <code language="none">
    /// {
    ///   "PrimaryIdentifier": "CARRIER21342",
    ///   "Units": [
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT1",
    ///       "X": 0.254,
    ///       "Y": 0.556,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT2",
    ///       "X": 6.254,
    ///       "Y": 0.556,
    ///       "Rotation": 90.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class IdentifiersRead : CFXMessage
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
        /// An optional list of actual production unit identifiers, in the case that multiple production units are moving through the 
        /// process, and the sensor is capable if reading multiple identifiers. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
