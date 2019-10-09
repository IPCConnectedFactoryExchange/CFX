using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of validations
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValidationType
    {
        /// <summary>
        /// A validation that ensures a unit is at the proper step in the route, and has completed all
        /// pre-requisite steps.
        /// </summary>
        UnitRouteValidation,
        /// <summary>
        /// A validation that ensures a unit is not in a failed or error condition
        /// </summary>
        UnitStatusValidation,
        /// <summary>
        /// A validation that ensures a unit and ALL of its sub-assemblies are not in a failed or error condition
        /// </summary>
        UnitAndSubsStatusValidation,
        /// <summary>
        /// Validates that the trace data has been recived for this unit from the sender by a factory level software system
        /// </summary>
        UnitTraceValidation,
        /// <summary>
        /// All known validations should be performed
        /// </summary>
        All
    }
}
