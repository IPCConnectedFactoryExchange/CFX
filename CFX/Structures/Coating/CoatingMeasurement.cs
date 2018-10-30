using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// Structure that describes the a particular measurement / reading that was taken by a coating or encapsulation
    /// endpoint in the course of dispensing.
    /// </summary>
    public class CoatingMeasurement : Measurement
    {
        [JsonIgnore]
        private CoatingMeasurementType measurementType;
        
        /// <summary>
        /// The type of reading
        /// </summary>
        public CoatingMeasurementType MeasurementType
        {
            get
            {
                return measurementType;
            }
            set
            {
                measurementType = value;
                if (MeasurementName == null && value != null) MeasurementName = value.ToString();
            }
        }

        /// <summary>
        /// The value of the reading (expressed in the appropriate units for the ReadingType).
        /// </summary>
        public double? ActualValue
        {
            get;
            set;
        }

        /// <summary>
        /// The nominal or expected value for this reading (expressed in the appropriate units for the ReadingType).
        /// </summary>
        public double? ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum accecptable value for this reading (expressed in the appropriate units for the ReadingType).
        /// </summary>
        public double? MinAcceptableValue
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum acceptable value for this reading (expressed in the appropriate units for the ReadingType).
        /// </summary>
        public double? MaxAcceptableValue
        {
            get;
            set;
        }
    }
}
