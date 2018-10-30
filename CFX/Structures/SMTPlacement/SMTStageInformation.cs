using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a stage (zone) for an endpoint that is an SMT placement machine.
    /// </summary>
    public class SMTStageInformation : StageInformation
    {
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
