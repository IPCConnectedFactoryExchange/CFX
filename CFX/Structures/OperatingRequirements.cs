using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Structure that specifies the operating requirements (environmental, etc.) 
    /// of a given endpoint.
    /// </summary>
    public class OperatingRequirements
    {
        /// <summary>
        /// The minimum level of relative humidity (expressed as a percentage from 0 to 1) required
        /// for the endpoint to operate
        /// </summary>
        public double MinimumHumidity
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum level of relative humidity (expressed as a percentage from 0 to 1) that the
        /// endpoint can tolerate
        /// </summary>
        public double MaximumHumidity
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum templerature (expressed in degrees Celsius) required
        /// for the endpoint to operate
        /// </summary>
        public double MinimumTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum templerature (expressed in degrees Celsius) that the endpoint can tolerate.
        /// </summary>
        public double MaximumTemperature
        {
            get;
            set;
        }
    }
}
