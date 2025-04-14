using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// Types of SMT Placement Faults
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DispensingFaultType
    {
        /// <summary>
        /// Insufficient air pressure
        /// </summary>
        AirPressureError,
        /// <summary>
        /// Problem with the x motion axis
        /// </summary>
        XAxisError,
        /// <summary>
        /// Problem with the y motion axis
        /// </summary>
        YAxisError,
        /// <summary>
        /// Problem with the z motion axis
        /// </summary>
        ZAxisError,
        /// <summary>
        /// Position not dispensed
        /// </summary>
        DispensingError,
        /// <summary>
        /// Error with the dispensing valve
        /// </summary>
        ValveError,
        /// <summary>
        /// Error decoding fiducial reference mark
        /// </summary>
        FiducialError,
        /// <summary>
        /// Material supply will soon be exhausted
        /// </summary>
        MaterialLowQuantity,
        /// <summary>
        /// Material supply is exhausted
        /// </summary>
        MaterialExhausted,
        /// <summary>
        /// Error detecting the reference height
        /// </summary>
        HeightSensingError,
        /// <summary>
        /// Workstage temperature is out of the set range
        /// </summary>
        WorkstageTempertatureOutOfRange,
        /// <summary>
        /// Nozzle temperature is out of the set range
        /// </summary>
        NozzleTemperatureOutOfRange
  }
}
