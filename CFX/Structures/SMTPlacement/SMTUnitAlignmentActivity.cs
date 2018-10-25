using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is aligned (located / positioned) within a stage
    /// of an SMT machine prior to the commencement of work.
    /// </summary>
    public class SMTUnitAlignmentActivity : UnitAlignmentActivity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SMTUnitAlignmentActivity()
        {
        }

        /// <summary>
        /// The Head used for the alignment
        /// </summary>
        public SMTHeadInformation Head
        {
            get;
            set;
        }
    }
}