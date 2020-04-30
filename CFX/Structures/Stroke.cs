using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the stroke structure as modelled in the Solder Paster Printing Process Data
    /// </summary>

    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Stroke
    {
        public Stroke()
        {
           
        }
        /// <summary>
        /// Stroke property Print pressure
        /// </summary>
        public double? PrintPressure { get; set; }
        /// <summary>
        /// Stroke property Print speed
        /// </summary>
        public double? PrintSpeed { get; set; }
    }
}
