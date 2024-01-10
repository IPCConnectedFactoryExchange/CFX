using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
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
        public List<Board> Boards { get; set; }
    }
}
