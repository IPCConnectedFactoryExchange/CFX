using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// NOTE:  ADDED in CFX 1.2
    /// Describes the stroke structure as modelled in the SolderPastePrintingRecipe
    /// </summary>

    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    [CFX.Utilities.CreatedVersion("1.2")]
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
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SolderPasteSqueegeeDirection
    {
        /// <summary>
        /// Forward
        /// </summary>
        forward,
        /// <summary>
        /// Backward
        /// </summary>
        backward
    }
}
