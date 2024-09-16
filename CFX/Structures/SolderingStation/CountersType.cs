using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Read-only or resetable counters
    /// </summary>
    public enum CountersType
    {
        /// <summary>
        /// Global read-only counters
        /// </summary>
        GLOBAL,
        /// <summary>
        /// Resetable counters
        /// </summary>
        PARTIAL
    }

}
