using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate the activation of a recipe by its name
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE3234",
    ///   "Revision": "B",
    ///   "Lane": 1,
    ///   "Stage": null
    /// }
    /// </code>
    /// </summary>
    public class RecipeActivated : CFXMessage
    {
        /// <summary>
        /// THe name of the recipe (may include full path, if applicable)
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0” (Optional)
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// Number of the production lane (if applicable)
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional stage
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of time that is expected to process one unit or group of units (as in the case of a carrier or panelized PCB), 
        /// assuming no blocked or starved conditions at the station.  This includes both productive and non-productive time, such as transfer, 
        /// positioning, etc.
        /// </summary>
        public double ExpectedCycleTime
        {
            get;
            set;
        }

        /// <summary>
        /// The number of units that are to be processed simulataneously by this recipe.  For example, in the case of a 2 x 2 panelized PCB, this
        /// property would be 4 because 4 units (PCB's) are procesed at one time per work transaction.  In the case that a station processes a
        /// variable number of units per transaction, this should represent the average number of units expected to be processed per transaction.
        /// </summary>
        public double ExpectedUnitsPerWorkTransaction
        {
            get;
            set;
        }
    }
}
