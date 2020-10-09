using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the sensor of the 
    /// resources / sub-resources in an Endpoint.
    /// It may be used to model the sensor on  
    /// parts that may require traceable operations (i.e. maintenance)
    /// </summary>
    public class SensorInformation : ResourceInformation
    {
        /// <summary>
        /// The type of the sensor in this position of the resource / machine.
        /// </summary>
        public SensorType Type
        {
            get;
            set;
        }
        
        /// <summary>
        /// The value of the performed verification.
        /// </summary>
        public double Value
        {
            get;
            set;
        }

        /// <summary>
        /// The low limit value of the performed verification (optional)
        /// </summary>
        public double? LowLimit
        {
            get;
            set;
        }

        /// <summary>
        /// The high limit value of the performed verification (optional)
        /// </summary>
        public double? HighLimit
        {
            get;
            set;
        }

        /// <summary>
        /// The unit of measure of the performed sample (if applicable)
        /// </summary>
        public SensorUnitOfMeasure UnitOfMeasure
        {
            get;
            set;
        }

        /// <summary>
        /// The last time when the verification has been executed
        /// </summary>
        public DateTime? SampleTime
        {
            get;
            set;
        }
    }
}
