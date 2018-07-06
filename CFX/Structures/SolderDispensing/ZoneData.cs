using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderDispensing
{
    public class ZoneData
    {
        public string Zone { get; set; }
        public string ProcessTime { get; set; }
        public string Bottle1_Pressure { get; set; }
        public string Bottle2_Pressure { get; set; }
        public string Flux_Volume { get; set; }
        public string Top_Preheater_Power { get; set; }
        public string Top_Preheater_Temp { get; set; }
        public string Top_Preheater_Heat { get; set; }
        public string Top_Preheater_Soak { get; set; }
        public string Fid_XCorrection { get; set; }
        public string Fid_YCorrection { get; set; }
        public string Bot_Preheater_Power { get; set; }
        public string Bot_Preheater_Temp { get; set; }
        public string Bot_Preheater_Heat { get; set; }
        public string Bot_Preheater_Soak { get; set; }
        public string Bath_Temp { get; set; }
        public string Bath_Wave_Enabled { get; set; }
        public string Bath_Wave_Hgt { get; set; }
        public string Solder_Quantity_Used { get; set; }
    }
}
