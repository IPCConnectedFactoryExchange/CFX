using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class UnitsDeparted
    {
        public UnitsDeparted()
        {
            Units = new List<UnitPosition>();
        }

        public int UnitCount
        {
            get
            {
                return Units.Count;

            }
            private set
            {
            }
        }

        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
