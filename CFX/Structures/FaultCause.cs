using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Possible causes of a fault that causes a stoppage in production
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FaultCause
    {
        /// <summary>
        /// A problem occurred loading a unit
        /// </summary>
        LoadError,
        /// <summary>
        /// A problem occurred unloading a unit
        /// </summary>
        UnloadError,
        /// <summary>
        /// A safety stop was automatically triggered by automation
        /// </summary>
        AutoSafetyStop,
        /// <summary>
        /// A safety stop was manually triggered by a human being
        /// </summary>
        SafetyStop,
        /// <summary>
        /// A stop was triggered due to a quality related problem
        /// </summary>
        QualityCheck,
        /// <summary>
        /// A stop was triggered remotely
        /// </summary>
        RemoteStop,
        /// <summary>
        /// A stop was induced by a mechanical failure
        /// </summary>
        MechanicalFailure,
        /// <summary>
        /// A stop was induced by a software failure
        /// </summary>
        SoftwareFailure,
        /// <summary>
        /// A stop was induced by a power failure
        /// </summary>
        PowerFailure,
        /// <summary>
        /// A stop was induced because required documentation was missing
        /// </summary>
        MissingDocumentation,
    }
}
