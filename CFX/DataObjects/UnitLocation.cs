using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX
{
    /// <summary>
    /// A data object identifying a single production unit being processed during production.  A single work transaction
    /// </summary>
    public class UnitLocation
    {
        [JsonProperty]
        public string UnitIdentifier
        {
            get;
            set;
        }

        [JsonProperty]
        public string LocationIdentifier
        {
            get;
            set;
        }
    }
}
