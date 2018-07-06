using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderDispensing
{
    public class SolderingData
    {
        public string UnitId { get; set; }
        public string Process_Status { get; set; }
        public string Program { get; set; }
        public string Barcode { get; set; }
        public string Nitrogen_Pressure { get; set; }
        public string Air_Pressure { get; set; }
        public string Cycle_Count { get; set; }
        public string Cycle_Time { get; set; }
        public string Nitrogen_Purity { get; set; }
        public string Nitrogen_Flow { get; set; }
        public string Fiducial_Enabled { get; set; }
    }
}
