using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderApplication
{
    /// <summary>
    /// Data specific to a single zone with the
    /// Selective Soldering System
    /// </summary>
    public class ZoneData
    {
        /// <summary>
        /// The identity of the zone for this set of process data.  
        /// Corresponds to the StageSequence number of the related Stage
        /// </summary>
        public int StageSequence
        {
            get;
            set;
        }

        /// <summary>
        /// The time the item was within this zone
        /// of the Selective Soldering System
        /// </summary>
        public TimeSpan ProcessTime
        {
            get;
            set;
        }

        /// <summary>
        /// Pressure of the Nitrogen for flux applicator 1
        /// in kPa (kilopascal)
        /// </summary>
        public double Bottle1_Pressure
        {
            get;
            set;
        }

        /// <summary>
        /// Pressure of the Nitrogen for flux applicator 2
        /// in kPa (kilopascal)
        /// </summary>
        public double Bottle2_Pressure
        {
            get;
            set;
        }

        /// <summary>
        /// The total volume of flux applied to the item
        /// in mg (milligrams)
        /// </summary>
        public double Flux_Volume
        {
            get;
            set;
        }

        /// <summary>
        /// The power setting for the top side preheater
        /// during the heating phase
        /// as a percentage (0-100%)
        /// </summary>
        public double Top_Preheater_Power
        {
            get;
            set;
        }

        /// <summary>
        /// The power setting for the top side preheater
        /// during the soak phase
        /// as a percentage (0-100%)
        /// </summary>
        public double Top_Preheater_Soak
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum temperature of the item
        /// during the preheating cycle
        /// in Celsius
        /// </summary>
        public double Top_Preheater_Temp
        {
            get;
            set;
        }

        /// <summary>
        /// The total time for the prehearting
        /// phase within this zone
        /// </summary>
        public TimeSpan Top_Preheater_Time
        {
            get;
            set;
        }

        /// <summary>
        /// The power setting for the bottom side preheater
        /// as a percentage (0-100%)        
        /// </summary>
        public double Bot_Preheater_Power
        {
            get;
            set;
        }

        /// <summary>
        /// The power setting for the bottom side preheater
        /// during the soak phase
        /// as a percentage (0-100%)
        /// </summary>
        public double Bot_Preheater_Soak
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum temperature of the item
        /// during the preheating cycle
        /// in Celsius
        /// </summary>
        public Single Bot_Preheater_Temp
        {
            get;
            set;
        }

        /// <summary>
        /// The total time for the prehearting
        /// phase within this zone
        /// </summary>
        public TimeSpan Bot_Preheater_Time
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature of the solder bath
        /// in Celsius
        /// </summary>
        public double Bath_Temp
        {
            get;
            set;
        }

        /// <summary>
        /// Solder Wave Height correction enabled 
        /// for the selective soldering system
        /// "True" or "False"
        /// </summary>
        public bool Bath_Wave_Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// The value the wave height was corrected by
        /// in mm (millimetres)
        /// </summary>
        public double Bath_Wave_Hgt
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of solder consumed by the soldering process
        /// in grams
        /// </summary>
        public double Solder_Quantity_Used
        {
            get;
            set;
        }

        /// <summary>
        /// The X-axis fiducial correction value
        /// in mm (millimetres)
        /// </summary>
        public double Fid_XCorrection
        {
            get;
            set;
        }

        /// <summary>
        /// The Y-axis fiducial correction value
        /// in mm (millimetres)
        /// </summary>
        public double Fid_YCorrection
        {
            get;
            set;
        }
    }
}
