using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        /// <summary>
        /// Time and date Production Unit entered oven in ISO 8061 Datetime format. 
        /// </summary>
        public string TimeDateUnitIn
        {
            get;
            set;
        }

        /// <summary>
        /// Time and date Production Unit exited oven in short date pattern.
        /// </summary>
        public string TimeDateUnitOut
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
        /// "IPM" (inches per minute), "FPM" (feet per minute), "MMPM"  (mm per minute), "CMPM"  (cm per minute), or "MPM"  (m per minute)
        /// </summary>
        public string ConveyorSpeedUnits
        {
            get;
            set;
        }

        /// <summary>
        /// Units set by ConveyorSpeedUnits
        /// </summary>
        public string ConveyorSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// Units set by ConveyorSpeedUnits
        /// </summary>
        public string MeasuredSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The speed (in cm / minute) of the conveyor
        /// </summary>
        public double ConveyorSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The convery speed setpoint (in cm / minute)
        /// </summary>
        public double ConveyorSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// "PASS" or "FAIL". FAIL if absolute value of ProductionUnitPWI exceeds 100.0
        /// </summary>
        public string Result
        {
            get;
            set;
        }

        /// <summary>
        /// "PASS" or "FAIL". FAIL if absolute value of ProductionUnitPWI exceeds 100.0
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
