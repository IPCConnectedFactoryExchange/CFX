using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// A specialized type of <see cref="Stage"/> that represents a zone within a wave soldering machine.
    /// </summary>
    public class WaveZone : Stage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WaveZone()
        {
            IsEnabled = true;
            WaveSubZones = new List<WaveSubZone>();
        }

        /// <summary>
        /// Indicates that this <seealso cref="WaveZone"/> is enabled or disabled (bypassed). By default it is <see cref="true"/>.
        /// </summary>
        public bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// The type/purpose of this zone.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public WaveZoneType WaveZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// A list of subzones in this zone. E.g. could be sub zones of type <see cref="WaveSubZoneType.Convection"/>, <see cref="WaveSubZoneType.Infrared"/> and <see cref="WaveSubZoneType.SolderFrameConveyor"/>
        /// </summary>
        public List<WaveSubZone> WaveSubZones
        {
            get;
            set;
        }
    }
}