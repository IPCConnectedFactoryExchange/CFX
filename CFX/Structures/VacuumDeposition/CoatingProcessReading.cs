
namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Dynamic structure base class contains process data.
    /// <code language="none">
    /// {
    ///   "Chamber Pressure": "100 mT",
    ///   "Vaporizer Temperature" : "150 °C",
    ///   "ElapsedTime" : "0 00:00:10"
    ///   }
    /// </code>
    /// </summary>
    public class CoatingProcessReading : Reading
    {
        /// <summary>
        /// Current Chamber Pressure in milliTor.
        /// </summary>
        public string ChamberPressure
        {
            get;
            set;
        }

        /// <summary>
        /// Current vaporizer temperature in degree Celsius.
        /// </summary>
        public string VaporizerTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// Elapsed time since process start.
        /// </summary>
        public string ElapsedTime
        {
            get;
            set;
        }
    }
}
