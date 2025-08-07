using System.Collections.Generic;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Describes all the tests that were performed to consider the component as valid or not,
    /// i.e. correctly picked, and also intrinsically valid
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class ComponentTests
    {
        /// <summary>
        /// Source of decision for the component validity
        /// </summary>
        public ComponentValidityDecisionSource DecisionSource
        {
            get;
            set;
        }
        
        /// <summary>
        /// The optical tests results of this component (optional)
        /// </summary>
        List<ComponentOpticalTest> OpticalTests
        {
            get;
            set;
        }

        /// <summary>
        /// The pressure tests results of this component (optional)
        /// </summary>
        List<ComponentPressureTest> PressureTests
        {
            get;
            set;
        }

        /// <summary>
        /// The vision tests results of this component (optional)
        /// </summary>
        List<ComponentVisionTest> VisionTests
        {
            get;
            set;
        }

        /// <summary>
        /// The electrical tests results of this component (optional)
        /// </summary>
        List<ComponentElectricalTest> ElectricalTests
        {
            get;
            set;
        }
    }
}
