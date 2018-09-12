using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderApplication
{
    /// <summary>
    ///  Message sent upon completion of the selective soldering process
    /// </summary>
    public class SelectiveSolderedPCB
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SelectiveSolderedPCB()
        {
            ZoneData = new List<ZoneData>();
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard).
        /// unit’s true unique identifier.  
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
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
