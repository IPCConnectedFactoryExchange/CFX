using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// The activity describes the installation or removal or exchange of a dispensing valve.
    /// </summary>
    public class ValveChangedActivity : Activity
    {
        /// <summary>
        /// The identifier of the head
        /// </summary>
        public string HeadId
        {
            get;
            set;
        }

        /// <summary>
        /// The valve which was removed from the head (if applicable)
        /// </summary>
        public DispenserValveInformation OldValve
        {
            get;
            set;
        }

        /// <summary>
        /// The valve which was installed on the head (if applicable)
        /// </summary>
        public DispenserValveInformation NewValve
        {
            get;
            set;
        }
    }
}