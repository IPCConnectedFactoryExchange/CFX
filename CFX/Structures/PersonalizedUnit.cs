using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes how a particular production unit has been personalized
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class PersonalizedUnit
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PersonalizedUnit()
        {
            Characteristics = new List<Characteristic>();
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (refer to CFX standard).
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// A list of personalized characteristics that have been applied to the production unit
        /// </summary>
        public List<Characteristic> Characteristics
        {
            get;
            set;
        }
    }
}
