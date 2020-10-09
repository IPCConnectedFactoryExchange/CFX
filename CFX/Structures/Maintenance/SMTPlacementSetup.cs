using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// Describes the actual setup resources / sub-resources of a particular Endpoint that is participating in a CFX network, 
    /// and more specifically, is an SMT placement machine.  This is a dynamic structure.
    /// </summary>
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
        public List<NozzleChangerGarage> NozzleChangerGarages
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the table of this SMT placement machine.
        /// </summary>
        public List<Table> Tables
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
