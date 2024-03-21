using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Device information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class Device
    {
        /// <summary>
        /// The device name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The serial number of the device.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// A list of processed boards.
        /// </summary>
        public List<HandSolderingBoardProcessData> HandSolderingBoardProcessData { get; set; }
    }
}
