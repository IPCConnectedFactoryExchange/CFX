using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Structure that contains information related to the feeder lifecycle. 
    /// It is used in maintenance context for maintenance scheduling and control etc.
    /// </summary>
    public class SMTTapeFeederInformation : ResourceInformation
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SMTTapeFeederInformation()
        {

        }
  
        /// <summary>
        /// List of lanes for a tape feeder 
        /// </summary>
        public List<MultiLane> MultiLanes
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Division class for feeder: given a track in the table, one feeder can serve multiple division (lane number).
    /// The counters are based on this sub-position, therefore the need of this object in the model.
    /// </summary>
    public class MultiLane
    {
        /// <summary>
        /// If available, information about the feeder counters of this SMT placement machine.
        /// </summary>
        public int? CycleCount
        {
            get;
            set;
        }
        /// <summary>
        /// For multi-lane tape feeders, this is the number of the position of the lane within the feeder.
        /// </summary>
        public int LaneNumber
        {
            get;
            set;
        }
        /// <summary>
        /// For multi-lane feeders, the unique identifier of the base. 
        /// The ResourceIdentifier property should be populated with the 
        /// unique identifer of the specific lane within the feeder (if so labeled). If lanes are not specifically labeled, 
        /// both the UniqueIdentifer and BaseUniqueIdentifier prooperties should be populated with the same value.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }
    }
}
