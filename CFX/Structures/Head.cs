using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Represents a generic head on an automated endpoint.  This is the base class of a dynamic structure, permitting
    /// for specialized heads derived from this class.  Examples of heads are SMT placement heads used in the placement
    /// of electronic components on PCB's, or a dispensing head, used in the dispensing of fluids or glues.
    /// </summary>
    public class Head
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Head()
        {
            HeadSequence = 1;
        }

        /// <summary>
        /// A unique identifier describing this particular head instance.  Typically,
        /// this identifier is barcoded or otherwise labeled on the head.
        /// </summary>
        public string HeadId
        {
            get;
            set;
        }

        /// <summary>
        /// Sequence of this head in the machine
        /// </summary>
        public int HeadSequence
        {
            get;
            set;
        }

        /// <summary>
        /// A friendly name for this head
        /// </summary>
        public string HeadName
        {
            get;
            set;
        }
    }
}
