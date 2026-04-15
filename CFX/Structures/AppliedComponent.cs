using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Describes a single component that was applied on a production unit, possibly
    /// in specific locations on the production unit.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class AppliedComponent : InstalledComponent
    {
        /// <summary>
        /// The quantity of the material that was applied, with defined units and thresholds
        /// </summary>
        [JsonProperty(Order = 1)]
        public NumericValue QuantityApplied
        {
            get;
            set;
        }

    }
}
