using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// Used by an endpoint to acquire information related to a particular work order (typically at the beginning of a Hermes enabled line).
    /// This information would typically then be passed down the line through the Hermes protocol / mechanism.
    /// </summary>
    public class GetWorkOrderDataRequest : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetWorkOrderDataRequest()
        {
            WorkOrderIdentifier = new WorkOrderIdentifier();
        }

        /// <summary>
        /// The identifier of the work order to look up.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// (OPTIONAL)  If work order informatoin is not known, an endpoint may also obtain work order data by instead populating
        /// this property with the identifier of a production unit that is associated with a work order and known to an upper 
        /// level control system.  The upper level control system will then look up the associated work order, and return the 
        /// appropriate work order information.
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

    }
}
