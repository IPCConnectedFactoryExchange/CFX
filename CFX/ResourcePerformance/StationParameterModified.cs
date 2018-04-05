using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint to indicate that an operator has modified a generic
    /// parameter or configuration setting. This does not apply to settings related to
    /// recipes, which are handled by the RecipeModified event. 
    /// </summary>
    public class StationParameterModified : CFXMessage
    {
        /// <summary>
        /// The name of the configuration setting which was modified
        /// </summary>
        public string ParameterName
        {
            get;
            set;
        }

        /// <summary>
        /// The previous value of this configuration setting
        /// </summary>
        public string OldParameterValue
        {
            get;
            set;
        }

        /// <summary>
        /// The new value of this configuration setting
        /// </summary>
        public string NewParameterValue
        {
            get;
            set;
        }
    }
}
