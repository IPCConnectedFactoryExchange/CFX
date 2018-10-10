using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    public class Head
    {
        public Head()
        {
            HeadSequence = 1;
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
