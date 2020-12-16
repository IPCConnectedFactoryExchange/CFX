using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    ///Provide information of the object to be inspected
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class InspectionItem
    {
        /// <summary>
        /// An optional field to specify the classification, like "Capacitor", "Resistor", "DPAK"
        /// </summary>
        public string Group
        {
            get;
            set;
        }
        /// <summary>
        /// Inspection object type enumeration 
        /// </summary>
        public InspectionItemType Type { get; set; }

        /// <summary>
        /// Unique Number of the inspection object, The No will be used in the Unit inspection messages to uniquely identify the Inspection step
        /// Its unique within this recipe
        /// </summary>
        public int RefNo { get; set; }

        /// <summary>
        /// An optional designators (instances of a part) on a production unit(s)
        /// May include sub-components in "." notation.  Examples:  R1, R2, R3   or  R2.3 (R2, pin 3)
        /// </summary>
        public string CRD
        {
            get;
            set;
        }

        /// <summary>
        /// Optional: The part number (internal) of the assembly to be produced by this Work Order.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }
        /// <summary>
        /// When available, it describes the shape of the inspected object.
        /// For example, if the object is a component (0201, 0402 etc.)
        /// </summary>
        public string PackageType
        {
            get;
            set;
        }

        /// <summary>
        /// Each Inspection is to be inspected applying one or more inspection steps
        /// Each inspection step is associated with a measurement
        /// </summary>
        public List<InspectionStep> Steps { get; set; }

    }
}
