using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when the work-cycle for a unit or group of units starts
    /// </summary>
    public class WorkStarted : CFXMessage
    {
        public WorkStarted()
        {
            TransactionID = Guid.NewGuid();
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// Transaction ID used to attach events and data during subsequent processing, until WorkCompleted
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// Lane number (1 – 99), or 0 if no specific lane
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The number of individual production units associated with this transaction.  May be more than 1 in the case of a carrier or panel of multiple PCB’s.
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
        /// Data that identifies each specific instance of production unit with a carrier or panel. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
