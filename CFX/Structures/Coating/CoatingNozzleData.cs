using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// Provides information about the conditions of a particular Nozzle of a Coating machine at a given point in time.
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class CoatingNozzleData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CoatingNozzleData()
        {
             NozzleReadings = new List<CoatingMeasurement>();
        }

        /// <summary>
        /// Coating Nozzle to which this coating data is related.
        /// </summary>
        public CoatingNozzle Nozzle
        {
            get;
            set;
        }

        /// <summary>
        ///  A list of readings / measurements that have been taken for this Nozzle.
        /// </summary>
        public List<CoatingMeasurement> NozzleReadings
        {
            get;
            set;
        }
    }
}
