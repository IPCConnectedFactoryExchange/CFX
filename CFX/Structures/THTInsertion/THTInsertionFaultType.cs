using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.THTInsertion
{
    /// <summary>
    /// Types of Through Hole Device Insertion Faults
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum THTInsertionFaultType
    {
        /// <summary>
        /// Error in x motion axis
        /// </summary>
        XAxisError,
        /// <summary>
        /// Error in y motion axis
        /// </summary>
        YAxisError,
        /// <summary>
        /// Error in z motion axis
        /// </summary>
        ZAxisError,
        /// <summary>
        /// Part not inserted properly
        /// </summary>
        InsertionError,
        /// <summary>
        /// Part cannot be properly aligned with PCB hole
        /// </summary>
        AlignmentError,
        /// <summary>
        /// Part could not be picked
        /// </summary>
        PickupError,
        /// <summary>
        /// Material supply exhausted
        /// </summary>
        PartsExhaustedError,
        /// <summary>
        /// Anvil related problem
        /// </summary>
        AnvilError,
        /// <summary>
        /// Clinch related problem
        /// </summary>
        ClinchError,
        /// <summary>
        /// PCB not properly aligned in fixture / transport
        /// </summary>
        PanelLocationError,
        /// <summary>
        /// Insufficient pressurized air supply
        /// </summary>
        AirSupplyDown,
    }
}
