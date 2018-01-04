using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum THTInsertionFaultType
    {
        XAxisError,
        YAxisError,
        ZAxisError,
        InsertionError,
        AlignmentError,
        PickupError,
        PartsExhaustedError,
        AnvilError,
        ClinchError,
        PanelLocationError,
        AirSupplyDown,
    }
}
