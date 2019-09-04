using System;
using System.Collections.Generic;
using CFX.Structures;

namespace CFX.Production.Application.VaccumDeposition
{
    /// <summary>
    /// Sent by a process endpoint, average coating thickness measurements.
    ///  <code language="none">
    /// {
    ///     "TransactionID":"e38629c0-bdec-4d72-9986-9d316f9403bb",
    ///     "Measurements":[
    ///     {
    ///         "Position":1,
    ///         "Thickness":"0.012300 mils",
    ///     },
    ///     {
    ///         "Position":2,
    ///         "Thickness":"0.056700 mils",
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class ThickenessMeasurements : CFXMessage
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ThickenessMeasurements()
        {
            TransactionID = Guid.NewGuid();
            Measurements = new List<CoatingMeasurement>();
        }

        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message.
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// Data list of average coating thickness measurements.
        /// </summary>
        public List<CoatingMeasurement> Measurements
        {
            get;
            set;
        }
    }
}
