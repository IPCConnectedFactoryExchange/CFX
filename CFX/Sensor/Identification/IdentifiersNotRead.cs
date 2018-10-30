using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Sensor.Identification
{
    /// <summary>
    /// Sent by an identification device (barcode scanner, RFID reader, etc.) when the device attempts to read or interpret
    /// an identifier, but is unable to do so.
    /// <para></para>
    /// <para>Example 1 (Simple, single barcode read)</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "PositionsNotRead": []
    /// }
    /// </code>
    /// <para>Example 2 (Camera system capable of reading all barcodes on a multi-circuit PCB panel)</para>
    /// <code language="none">
    /// {
    ///   "PositionsNotRead": [
    ///     2,
    ///     8
    ///   ]
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    public class IdentifiersNotRead : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public IdentifiersNotRead()
        {
            PositionsNotRead = new List<int>();
        }

        /// <summary>
        /// And optional property indicated the position that cannot be read.  Used in the case that multiple 
        /// production units are moving through the process, and the sensor is capable if reading multiple identifiers.
        /// </summary>
        public List<int> PositionsNotRead
        {
            get;
            set;
        }
    }
}
