using System;
using CFX.Structures;

namespace CFX.Production.Application.VaccumDeposition
{
    /// <summary>
    ///  Sent by a process endpoint, current process data for the coating cycle.
    /// <code language="none">
    /// {
    ///     "TransactionID":"e38629c0-bdec-4d72-9986-9d316f9403bb",
    ///     "Process_Data":
    ///     {
    ///         "ChamberPressure":"160 mT",
    ///         "VaporizerTemperature":"52 ⁰C,
    ///         "ElaspedTime":0 00:00:10
    ///     }
    /// }
    /// </code>
    /// </summary>
    public class CurrentProcessData : CFXMessage
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CurrentProcessData()
        {
            TransactionID = Guid.NewGuid();
            Process_Data = new CoatingProcessData();
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
        /// "ProcessData": "Vaporizer Temperature, Chamber Pressure"
        /// </summary>
        public CoatingProcessData Process_Data
        {
            get;
            set;
        }
    }
}
