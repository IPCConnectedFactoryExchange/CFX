using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes and SMT Tray Feeder
    /// </summary>
    public class SMDTrayFeeder : MaterialCarrier
    {
        public double CellDimensionX
        {
            get;
            set;
        }
        public double CellDimensionY
        {
            get;
            set;
        }

        public int CellCountX
        {
            get;
            set;
        }

        public int CellCountY
        {
            get;
            set;
        }
    }
}
