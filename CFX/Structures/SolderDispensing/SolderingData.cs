using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderDispensing
{
    /// <summary>
    /// General data values that apply across the selective process cycle 
    /// </summary>
    public class SolderingData
    {
        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard).
        /// unit’s true unique identifier.  
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Result of the Selective Process
        /// "Completed" or "Aborted"
        /// </summary>
        public string Process_Status
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the active recipe at the time when the processing occurred.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Pressure od the incoming Nitrogen
        /// in kPa (kilopascal)
        /// </summary>
        public Single Nitrogen_Pressure
        {
            get;
            set;
        }

        /// <summary>
        /// Pressure od the incoming Air
        /// in kPa (kilopascal)
        /// </summary>        
        public Single Air_Pressure
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of parts processed
        /// since the last reset of the Cycle Counter
        /// </summary>
        public Int16 Cycle_Count
        {
            get;
            set;
        }

        /// <summary>
        /// The total time the item was within the Selective Soldering System
        /// </summary>        
        public TimeSpan Cycle_Time
        {
            get;
            set;
        }

        /// <summary>
        /// The Purity of the incoming Nitrogen supply
        /// in ppm (parts per million)
        /// </summary>
        public Single Nitrogen_Purity
        {
            get;
            set;
        }

        /// <summary>
        /// The consumption of Nitrogen by the selective soldering system
        /// in LPM (litres per minute)
        /// </summary>        
        public Single Nitrogen_Flow
        {
            get;
            set;
        }

        /// <summary>
        /// Fiducial correct enabled for the selective soldering system
        /// "True" or "False"
        /// </summary>
        public Boolean Fiducial_Enabled
        {
            get;
            set;
        }
    }
}
