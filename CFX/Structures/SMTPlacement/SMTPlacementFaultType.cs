using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTPlacementFaultType
    {
        VacuumError,
        XAxisError,
        YAxisError,
        ZAxisError,
        RecognitionError,
        PickupError,
        PlacementError,
        LightingError,
        HeadError,
        NozzleError,
        ComponentDropped,
        PartsExhaust,
        FiducialError
    }
}
