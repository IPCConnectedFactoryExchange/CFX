using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Sensor.Identification
{
    /// <summary>
    /// Sent by a process endpoint to a unit identification device (such as a barcode scanner or RFID reader)
    /// to request the most recently scanned unit identifiers.
    /// <code language="none">
    /// {}
    /// </code>
    /// </summary>
    public class IdentifyUnitsRequest : CFXMessage
    {
    }
}
