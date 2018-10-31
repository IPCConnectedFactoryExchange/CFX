using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures.SolderReflow;

namespace CFX.Structures.ReflowProfiling
{
    /// <summary>
    /// Provides production unit reflow statistics
    /// </summary>
    public class ReflowProfilingProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReflowProfilingProcessData()
        {
            ZoneData = new List<ReflowZoneData>();
            TimeDateUnitIn = DateTime.Now;
            TimeDateUnitOut = DateTime.Now;
        }

        /// <summary>
        /// Time and date Production Unit entered oven in ISO 8061 Datetime format. 
        /// </summary>
        public DateTime TimeDateUnitIn
        {
            get;
            set;
        }

        /// <summary>
        /// Time and date Production Unit exited oven in short date pattern.
        /// </summary>
        public DateTime TimeDateUnitOut
        {
            get;
            set;
        }

        /// <summary>
        /// Name of product
        /// </summary>
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// Barcode of Production Unit
        /// </summary>
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// Name of recipe
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Name of process window
        /// </summary>
        public string ProcessWindowName
        {
            get;
            set;
        }

        /// <summary>
        /// Lot identification value
        /// </summary>
        public string LotID
        {
            get;
            set;
        }

        /// <summary>
        /// Name of oven
        /// </summary>
        public string OvenName
        {
            get;
            set;
        }

        /// <summary>
        /// Lane within oven. 1 is “front” and 2 is “back”
        /// </summary>
        public ushort Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The converyor speed setpoint (in cm / minute)
        /// </summary>
        public double ConveyorSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The actual conveyor speed (in cm / minute)
        /// </summary>
        public double MeasuredConveyorSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// "PASS" or "FAIL". FAIL if absolute value of ProductionUnitPWI exceeds 100.0
        /// </summary>
        public TestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The Process Window Index of the production unit
        /// </summary>
        public double ProductionUnitPWI
        {
            get;
            set;
        }

        /// <summary>
        /// Process data (temperatures, etc.) for each zone of the reflow oven at the 
        /// time when this transaction tool place.
        /// </summary>
        public List<ReflowZoneData> ZoneData
        {
            get;
            set;
        }
    }
}
