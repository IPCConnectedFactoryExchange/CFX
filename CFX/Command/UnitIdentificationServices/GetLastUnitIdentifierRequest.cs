using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Command.UnitIdentificationServices
{
    /// <summary>
    /// Requests the most recently acquired production unit identifier from a device.
    /// This allows a device or automated work center that does not have its own internal
    /// barcode or RFID reader to acquire unit identifiers from external devices (conveyor
    /// mounted scanning device, for example) prior to commencing work on a production unit
    /// (thereby allowing the work center to generate its own messages containing real unit
    /// identifiers during processing).
    /// </summary>
    public class GetLastUnitIdentifierRequest
    {
    }
}
