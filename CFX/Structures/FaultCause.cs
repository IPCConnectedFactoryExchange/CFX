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
    /// Possible causes of a fault that may causes a stoppage in production
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
        /// <summary>
        /// A stop was induced because material requires a refill of an empty consumable material 
        /// </summary>
        Refill,
        /// <summary>
        /// A stop was induced because required material moisture sensitive  status has been expired
        /// </summary>
        MsdExpired,
        /// <summary>
        /// A stop was induced because required consumable material due date status has been expired
        /// </summary>
        MaterialExpired,
        /// <summary>
        /// A stop was induced because required consumable material is missing 
        /// </summary>
        MissingComponent,
        /// <summary>
        /// A stop was triggered by an electrical device failure (i.e. Sensor failed) 
        /// </summary>
        ElectricalFailure,        
        /// <summary>
        /// A stop was triggered by a services failure (i.e. Lack of air pressure)
        /// </summary>
        ServicesFailure,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.2 **</para>
        /// A stop was triggered due to process error.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.2")]
        ProcessError,
        /// <summary>
        /// A stop was induced because a consumable material has been rejected
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        RejectedComponent,
    }
}
