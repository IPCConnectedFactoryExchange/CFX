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
    public enum FaultCause
    {
        LoadError,
        UnloadError,
        AutoSafetyStop,
        SafetyStop,
        QualityCheck,
        RemoteStop,
        MechanicalFailure,
        SoftwareFailure,
        PowerFailure,
        MissingDocumentation,
    }
}
