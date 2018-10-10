using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Reason why a component or material was uninstalled from a production unit
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UninstalledReason
    {
        /// <summary>
        /// The component or material was defective, and had to be replaced.
        /// </summary>
        DefectiveMaterial,
        /// <summary>
        /// The component or material was not installed correctly, and had to be replaced or re-installed
        /// </summary>
        DefectiveInstallation,
        /// <summary>
        /// The wrong component or material was installed, and had to be replaced.
        /// </summary>
        IncorrectMaterial,
        /// <summary>
        /// The component or material was uninstalled for a reason not covered by this enumeration.
        /// </summary>
        Other,
    }
}
