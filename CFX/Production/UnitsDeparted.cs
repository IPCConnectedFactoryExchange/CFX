using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when units physically depart from a process endpoint. 
    /// This does not imply any information about any activity that may have taken place.
    /// </summary>
    public class UnitsDeparted : CFXMessage
    {
        public UnitsDeparted()
        {
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// The number of individual production units
        /// </summary>
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

        /// <summary>
        /// List of structures that identify each specific instance of production unit that departed (could be within a carrier or panel). 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
