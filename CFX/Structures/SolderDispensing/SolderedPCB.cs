using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderDispensing
{
    /// <summary>
    ///  Message sent upon completion of the selective soldering process
    /// </summary>
    public class SolderedPCB
    {
        /// <summary>
        /// General data values that apply across the selective process cycle
        /// </summary>
        public SolderingData HeaderData
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
