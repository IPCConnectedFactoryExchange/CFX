using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// Describes the resources / sub-resources of a particular Endpoint that is participating in a CFX network, 
    /// and more specifically, is an SMT placement machine.  This is a dynamic structure.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class MaintenanceResource : Resource
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MaintenanceResource()
        {
           
        }

        /// <summary>
        /// Generic list for the sub-resources in this resource (machine)
        /// </summary>
        public List<ResourceInformation> Resources
        {
            get;
            set;
        }
    }
}
