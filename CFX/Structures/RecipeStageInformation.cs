using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CFX.Structures
{
    /// <summary>
    /// Describes some information about a recipe for a specific  stage
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class RecipeStageInformation
    {
        /// <summary>
        /// A structure describing basic information about the stage.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of time that is expected to process one unit or group of units (as in the case of a carrier or panelized PCB) for a stage of the machine, 
        /// assuming no blocked or starved conditions at the station. This includes both productive and non-productive time, such as transfer, 
        /// positioning, etc.
        /// </summary>
        public double ExpectedCycleTime
        {
            get;
            set;
        }

        /// <summary>
        /// The number of components to install for each unit of a work for a stage of the machine.
        /// </summary>
        public double NumberOfComponentsPerUnit
        {
            get;
            set;
        }
    }
}
