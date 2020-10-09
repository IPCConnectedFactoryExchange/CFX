using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the resources / sub-resources in an Endpoint.
    /// It may be used to model, among the others: camera, conveyor, gantries and other 
    /// parts that may require traceable operations (i.e. maintenance)
    /// </summary>
    public class ResourceInformation
    {
        /// <summary>
        /// Name of the resource / sub-resource in the endpoint
        /// </summary>
        public string ResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// The internal identifier (if applicable) of the part that is installed at this position.
        /// </summary>
        public string ResourceIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the part that is installed at this position.
        /// </summary>
        public string ResourceType
        {
            get;
            set;
        }

        /// <summary>
        /// The position where the required part is installed on the Endpoint (optional). 
        /// Where applicable, a dot (".") notation should be utilized to designate specific positions.
        /// Examples: MODULE1.BEAM1.HEADPOS2, MODULE1.NEST3.NOZZLESLOT4, etc.
        /// </summary>
        public string ResourcePosition
        {
            get;
            set;
        }

        /// <summary>
        /// The maintenance status for this resource
        /// </summary>
        public MaintenanceStatus MaintenanceStatus
        {
            get;
            set;
        }
    }
}
