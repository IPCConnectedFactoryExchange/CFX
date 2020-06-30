using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CFX.Structures.PCBInspection
{

    /// <summary>
    /// Representing a physical object (panel, board, component, fiducial, pin) with features to check
    /// during inspection.
    /// </summary>
    public class InspectionObject : NamedObject
    {

        /// <summary>
        /// Features to check during inspection, like "Presence", "Displacement", "Height".
        /// </summary>
        public List<Feature> Features { get; set; }


        /// <summary>
        /// The inspection object is defective, i.e.
        /// - it was detected as defect,
        /// - not verified as "false call",  and
        /// - not repaired.
        /// </summary>
        [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
        public virtual bool IsDefect
        {
            get
            {
                if (IsRepaired)
                    return false;  // The component as a whole was repaired, so it is not defect anymore.

                foreach (Feature feature in Features ?? Enumerable.Empty<Feature>())
                {
                    if (feature.IsDefect)
                        return true; // At least one feature is defective, so this inspection object is defective.
                }

                return false; // No defect in any of our features.
            }
        }

        /// <summary>
        /// The inspection object as a whole was repaired. (E.g. by replacing the whole component.)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsRepaired { get; set; } = false;


    }

}
