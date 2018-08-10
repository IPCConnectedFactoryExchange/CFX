using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a stage (work zone) for an endpoint that is an SMT placement machine.
    /// </summary>
    public class SMTStageInformation
    {
        /// <summary>
        /// The name of this stage.  Corresponds with Stage property in production messages.
        /// </summary>
        public string StageName
        {
            get;
            set;
        }

        /// <summary>
        /// The number of stations where a feeder may be mounted for this stage.
        /// </summary>
        public int NumberOfFeederStations
        {
            get;
            set;
        }
    }
}
