using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a particular head of an automated endpoint that uses one or more heads in the course of its work.
    /// </summary>
    public class HeadInformation
    {
        /// <summary>
        /// A structure describing basic information about the head.
        /// </summary>
        public Head Head
        {
            get;
            set;
        }
    }
}
