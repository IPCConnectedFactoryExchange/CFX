using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CFX.Structures.PCBInspection
{

    /// <summary>
    /// A component as a resistor, capacitor, IC, ...
    /// Typically has (two or more) pins (as its "children").
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Component : GeometricObject
    {
        /// <summary>
        /// Component type, e.g. "C1206", "R1206", "TO252AA".
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Group of component classification like "Capacitor", "Resistor", "DPAK".
        /// </summary>
        public String Group { get; set; }

        /// <summary>
        /// List of Pins of this component.
        /// </summary>
        [JsonProperty(Order = 1)]   // The children should come at the end.
        public List<Pin> Pins { get; set; }


        /// <summary>
        /// Checks if this component (or one of its pins) is defect.
        /// </summary>
        [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
        public override bool IsDefect
        {
            get
            {
                if (IsRepaired)
                    return false;  // The component as a whole was repaired, so it is not defect anymore.

                if (base.IsDefect)
                    return true;  // The inspection object itself is defect.

                // Check all children recursively.

                foreach (Pin pin in Pins ?? Enumerable.Empty<Pin>())
                {
                    if (pin.IsDefect)
                        return true; // At least one fiducial is defect, so this inspection object is considered defect.
                }

                return false; // No defect in any of our features or pins.
            }
        }

        /// <summary>
        /// The internal part number of the designated component.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public string PartNumber
        {
            get;
            set;
        }


    }

}
