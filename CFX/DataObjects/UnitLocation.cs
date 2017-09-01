using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX
{
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
