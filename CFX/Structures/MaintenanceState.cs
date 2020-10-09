using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Maintenance status provides the information about the condition of a
    /// resource in a resource / machine.
    /// </summary>
    public class MaintenanceStatus
    {
        /// <summary>
        /// The reason why the feeder should be locked in case of result state is not ok  
        /// </summary>
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// The result status of the response to the request.
        /// </summary>
        public MaintenanceState ResultState
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Possible Maintenance status. It is used in the response message, after 
    /// the endpoint / resource has sent a status info request
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaintenanceState
    {
        /// <summary>
        /// Maintenance status is not known
        /// </summary>
        Unknown,
        /// <summary>
        /// Maintenance status is Ok
        /// </summary>
        Ok,
        /// <summary>
        /// Maintenance status is Not ok
        /// </summary>
        NotOk
    }
}
