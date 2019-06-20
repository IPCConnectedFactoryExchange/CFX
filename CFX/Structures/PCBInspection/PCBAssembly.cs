using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.PCBInspection
{
    /// <summary>
    /// Represents a PCB Assembly that is processed and inspected by a piece of inspection equipment (such as an AOI or SPI machine),
    /// or by a human inspector.
    /// </summary>
    public class PCBAssembly : Assembly
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PCBAssembly()
        {

        }

        /// <summary>
        /// A data structure representing the PCB panel that is to be inspected.  
        /// This could be a single PCB, an panel with multiple PCBs, or even a structure
        /// of PCBs containing sub-PCBs.
        /// </summary>
        public Panel Panel
        {
            get;
            set;
        }
    }
}
