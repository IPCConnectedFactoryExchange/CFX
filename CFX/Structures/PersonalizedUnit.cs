using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class PersonalizedUnit
    {
        public PersonalizedUnit()
        {
            Characteristics = new List<Characteristic>();
        }

        public string UnitIdentifier
        {
            get;
            set;
        }

        public int? UnitPositionNumber
        {
            get;
            set;
        }

        public List<Characteristic> Characteristics
        {
            get;
            set;
        }
    }
}
