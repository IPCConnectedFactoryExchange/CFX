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
    public class UnitPosition
    {
        [JsonProperty]
        public string UnitIdentifier
        {
            get;
            set;
        }

        [JsonProperty]
        public int PositionNumber
        {
            get;
            set;
        }

        public string PositionName
        {
            get;
            set;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        public double Rotation
        {
            get;
            set;
        }
    }
}
