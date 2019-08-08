using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderApplication
{
    /// <summary>
    /// Process Data specific to a single PCB within a group of PCB's that are selectively
    /// soldered.
    /// </summary>
    public class SelectiveSolderPCBProcessData : ProcessData
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectiveSolderPCBProcessData()
        {
            ZoneData = new List<ZoneData>();
        }

        /// <summary>
        /// Data sepcific to a single zone with the
        /// Selective Soldering System
        /// </summary>
        public List<ZoneData> ZoneData
        {
            get;
            set;
        }
    }
}
