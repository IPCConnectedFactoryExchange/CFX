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
        public string ParameterName
        {
            get;
            set;
        }

        public string OldParameterValue
        {
            get;
            set;
        }

        public string NewParameterValue
        {
            get;
            set;
        }
    }
}
