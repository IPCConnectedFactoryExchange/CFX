using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderApplication
{
    /// <summary>
    /// A specialized type of Activity that occurs within a Selective Soldering System.
    /// </summary>
    public class SelectiveActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SelectiveActivity()
        {
            ActivityName = "SELECTIVE ACTION";
            ValueAddType = ValueAddType.NonValueAdd;
        }
        /// <summary>
        /// The action that occured,
        /// examples: Solder Pump, Fluxer, Preheater
        /// </summary>
        public string Action
        {
            get;
            set;
        }                        
    }
}
