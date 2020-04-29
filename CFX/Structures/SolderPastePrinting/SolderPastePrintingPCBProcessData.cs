using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX;
using CFX.Structures;

namespace CFX.Structures.SolderPastePrinting
{
    public class SolderPastePrintingPCBProcessData
    {
        /// <summary>
        /// The new Process Data for the PCB processed.
        /// </summary>
        public SolderPastePrintingPCBProcessData()
        {

        }
        /// <summary>
        /// Printing offset on the X-Axis
        /// </summary>
        public double? Offset_X { get; set; }
        /// <summary>
        /// Printing offset on the Y-Axis
        /// </summary>
        public double? Offset_Y { get; set; }
        /// <summary>
        /// Printing offset on the Theta-Axis
        /// </summary>
        public double ? Offset_Theta { get; set; }
        /// <summary>
        /// First direction of the Printing process
        /// </summary>
        public string FirstPrintDirection { get; set; }
        /// <summary>
        /// Cycle time for the Printing process, in the format hh:mm:ss.fffffff
        /// </summary>
        public string Cycle_Time { get; set; }

    }
}
