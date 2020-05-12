using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is under placement
    /// </summary>
    public class SMTPlacementActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SMTPlacementActivity()
        {
            ActivityName = "PLACEMENT";
            ValueAddType = ValueAddType.RealValueAdd;
            Heads = new List<SMTHeadInformation>();
        }

        /// <summary>
        /// The type of placement for this activity
        /// </summary>
        public SMTPlacementType PlacementType
        {
            get;
            set;
        }

        /// <summary>
        /// The Heads used for the placement
        /// </summary>
        public List<SMTHeadInformation> Heads
        {
            get;
            set;
        }
    }
}