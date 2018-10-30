using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a stage (zone) for an endpoint that is in a machine.
    /// </summary>
    public class StageInformation
    {
        /// <summary>
        /// A structure describing basic information about the stage.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }
    }
}
