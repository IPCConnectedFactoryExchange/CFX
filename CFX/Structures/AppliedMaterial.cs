using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Describes a single lot of material that was applied on a production unit, possibly
    /// in specific locations on the production unit.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class AppliedMaterial : InstalledMaterial
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
