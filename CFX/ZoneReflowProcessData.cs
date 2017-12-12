using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    public class ZoneReflowProcessData
    {
        public ZoneReflowProcessData()
        {
            AmbientConditions = new List<CFX.Measurement>();
            UnitExperience = new List<CFX.Measurement>();
        }

        public string ZoneName
        {
            get;
            set;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ZoneType ZoneType
        {
            get;
            set;
        }

        
        public List<Measurement> AmbientConditions
        {
            get;
            set;

        }

        public List<Measurement> UnitExperience
        {
            get;
            set;
        }
    }

    public enum ZoneType
    {
        PreHeat,
        Soak,
        Reflow,
        Cool
    }
}
