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
        /// <para>** NOTE: CHANGED in CFX 1.2 from single head to multiple heads **</para>
        /// The Heads used for the placement
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        public List<SMTHeadInformation> Heads
        {
            get;
            set;
        }
    }
}