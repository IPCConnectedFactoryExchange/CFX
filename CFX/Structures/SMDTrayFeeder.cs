using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
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
