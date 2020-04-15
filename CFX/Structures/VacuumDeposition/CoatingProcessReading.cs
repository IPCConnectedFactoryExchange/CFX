using System;

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Structure base class representing process data.
    /// Chamber pressure units in mbar.
    /// Vaporizer temperature in degrees Celsius.
    /// <code language="none">
    /// {
    ///   "Chamber Pressure": "100",
    ///   "Vaporizer Temperature" : "150"
    ///   }
    /// </code>
    /// </summary>
    /// 

    public class CoatingProcessReading : Reading
    {
        /// <summary>
        /// Current chamber pressure in mbar.
        /// </summary>
        public double ChamberPressure
        {
            get;
            set;
        }

        /// <summary>
        /// Current vaporizer temperature in degrees Celsius.
        /// </summary>
        public double VaporizerTemperature
        {
            get;
            set;
        }
    }
}
