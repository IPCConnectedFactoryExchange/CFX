using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is loaded into an endpoint.
    /// </summary>
    public class SMTNozzleChangeActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SMTNozzleChangeActivity()
        {
            ActivityName = "NOZZLE CHANGE";
            ValueAddType = ValueAddType.NonValueAdd;
            OldNozzles = new List<SMTHead>();
            NewNozzles = new List<SMTHead>();
        }

        /// <summary>
        /// The nozzles that were removed (if known)
        /// </summary>
        public List<SMTHead> OldNozzles
        {
            get;
            set;
        }

        /// <summary>
        /// The new nozzles that were loaded (mandatory)
        /// </summary>
        public List<SMTHead> NewNozzles
        {
            get;
            set;
        }
    }
}
