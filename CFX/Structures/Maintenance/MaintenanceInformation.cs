using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the counters of the 
    /// resources / sub-resources in an Endpoint. It is the information that allows the
    /// receiving system to plan / execute the maintenance operations
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class MaintenanceInformation
    {
        /// <summary>
        /// The user friendly name of counter data source.
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// The type of the counter for this element.
        /// </summary>
        public CounterType CounterType
        {
            get;
            set;
        }
        /// <summary>
        /// Optional field. 
        /// When CounterType = NonStandard, this field allows the sender to specify a custom counter
        /// </summary>
        public string CustomCounterType
        {
            get;
            set;
        }
        /// <summary>
        /// The location of the data source providing the counter information (optional, only if available).
        /// It may be used to distinguish, for example, the counters of multi-lane feeder
        /// Where applicable, a dot (".") notation should be utilized to designate specific positions.
        /// Examples: MODULE1.BEAM1.HEADPOS2, MODULE1.NEST3.NOZZLESLOT4, etc.
        /// </summary>
        public string MeasurementLocation
        {
            get;
            set;
        }
        /// <summary>
        /// The current value of the counter.
        /// </summary>
        public double? CurrentCounterValue
        {
            get;
            set;
        }

        /// <summary>
        /// The current maintenance ratio at reading time. This value is close to 0 for 
        /// recent executed maintenance and close to 100 for parts requiring maintenance.
        /// NOTE: this value may be also more than 100
        /// </summary>
        public double? CurrentRatio
        {
            get;
            set;
        }
        /// <summary>
        ///Provides additional information on the lifetime usage of this part. 
        ///It is "false" for parts which do not own an independent maintenance cycle.
        ///Instead, the maintenance is done as part of a higher level resource 
        ///(for example the maintenance of rotation-axis, star axis, and z axis are part of head maintenance) or not at all
        /// </summary>
        public bool? CurrentRatioValid
        {
            get;
            set;
        }
        /// <summary>
        /// Timestamp when the maintenance counter was sampled. 
        /// </summary>
        public DateTime? CurrentTimeStamp
        {
            get;
            set;
        }
        /// <summary>
        /// The value of the counter during the last maintenance
        /// </summary>
        public double? LastMaintenanceCounterValue
        {
            get;
            set;
        }
        /// <summary>
        /// Timestamp when the last maintenance was done. 
        /// </summary>
        public DateTime? LastMaintenanceTimeStamp
        {
            get;
            set;
        }
        /// <summary>
        ///It is true, if at least one maintenance was succesfully done.
        ///If false, both LastMaintenanceCounterValue and LastMaintenanceTimeStamp are invalid and cannot be used. 
        /// </summary>
        public bool? LastMaintenanceValid
        {
            get;
            set;
        }
    }
}
