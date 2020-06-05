using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX;
using CFX.Structures;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.2 **</para>
    /// The new Process Data for the PCB processed.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class SolderPastePrintingPCBProcessData : ProcessData
    {
        /// <summary>
        /// Constructor class for the new object.
        /// </summary>
        public SolderPastePrintingPCBProcessData()
        {

        }
        /// <summary>
        /// List of Stroke objects for Solder Paste Printing PCB Process Data
        /// </summary>
        public List<Stroke> Strokes { get; set; }
        /// <summary>
        /// Separation object 
        /// </summary>
        public Separation Separation { get; set; }
        /// <summary>
        /// Periodic cleaning object List. Normally it shall be one, but in this way it may be extended more easily 
        /// </summary>
        public List<PeriodicCleaning> PeriodicCleanings { get; set; }
        /// <summary>
        /// Recipe name for the process data
        /// </summary>
        public string RecipeName { get; set; }
        /// <summary>
        /// Printing offset on the X-Axis
        /// </summary>
        public double? OffsetX { get; set; }
        /// <summary>
        /// Printing offset on the Y-Axis
        /// </summary>
        public double? OffsetY { get; set; }
        /// <summary>
        /// Printing offset on the Theta-Axis
        /// </summary>
        public double ? OffsetTheta { get; set; }
        /// <summary>
        /// First direction of the Printing process
        /// </summary>
        public string FirstPrintDirection { get; set; }
        /// <summary>
        /// Cycle time for the Printing process, in the format hh:mm:ss.fffffff
        /// </summary>
        public TimeSpan CycleTime { get; set; }

    }
}
