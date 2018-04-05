using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a location on a process endpoint where a tool may be stored.
    /// </summary>
    public class ToolHolder
    {
        /// <summary>
        /// Unique identifier of the tool holder (barcode, RFID, etc.)
        /// </summary>
        public string LocationUniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the tool holder location
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        /// <summary>
        /// If this tool holder is part of a nest or group of nozzle holders, 
        /// this is the nest or group name.
        /// </summary>
        public string BaseName
        {
            get;
            set;
        }
    }
}
