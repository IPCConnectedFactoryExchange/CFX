using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CFX.Structures.Production.TestAndInspection
{

    /// <summary>
    /// Representing a physical object (panel, board, component, fiducial, pin) with features to check
    /// during inspection.
    /// </summary>
    public class InspectionObject : NamedObject
    {
        /// <summary>
        /// Reference to the parent inspection object. Allows to calculate the absolute position and rotation.
        /// </summary>
        [JsonIgnore]  // This property is reconstructed _after_ deserialization via UpdateParentReference(). It would be nice, if JSON.NET could fill
                      // it automatically, but that seems impossible for now. Maybe with future serialization techniques...
        public InspectionObject Parent { get; set; } = null;

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

                foreach (Feature feature in Features ?? Enumerable.Empty<Feature> ())
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
        [JsonProperty (DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsRepaired { get; set; } = false;


        /// <summary>
        /// Update the reference to the parent object, recursively for all children.
        /// </summary>
        /// <param name="x_parent">The parent inspection object.</param>
        public virtual void UpdateParentReference (InspectionObject x_parent)
        {
            Parent = x_parent;

            // Derived classes need to update all their children, too.
            // (Typically with "this" as parent, of course.)
        }
    }

}
