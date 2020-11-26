using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures.SMTPlacement;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// Describes the actual setup resources / sub-resources of a particular Endpoint that is participating in a CFX network, 
    /// and more specifically, is an SMT placement machine.  This is a dynamic structure.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class SMTPlacementSetup : Resource
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SMTPlacementSetup()
        {
           
        }

        /// <summary>
        /// Information about the nozzle changer garages of this SMT placement machine.
        /// </summary>
        public List<SMTNozzleChangerPocket> NozzleChangerPockets
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the table of this SMT placement machine.
        /// </summary>
        public List<SMTTable> Tables
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the feeder of this SMT placement machine.
        /// </summary>
        public List<ResourceInformation> Feeders
        {
            get;
            set;
        }
    }
}
