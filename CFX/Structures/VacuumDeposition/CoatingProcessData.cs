using System;

namespace CFX.Structures
{
    /// <summary>
    /// Structure contains process data.
    /// </summary>
    public class CoatingProcessData
    {
        /// <summary>
        /// Current Chamber Pressure in milli Torr.
        /// </summary>
        public string ChamberPressure
        {
            get;
            set;
        }

        /// <summary>
        /// Current vaporizer temperature in degree celsius.
        /// </summary>
        public string VaporizerTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// Elasped time since process start.
        /// </summary>
        public string ElaspedTime
        {
            get;
            set;
        }
    }
}
