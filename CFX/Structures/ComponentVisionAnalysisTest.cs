using System.Collections.Generic;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Describes details on a vision analysis test of a component
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class ComponentVisionAnalysisTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentVisionAnalysisTest()
        {
        }

        /// <summary>
        /// The type of the vision analysis test
        /// </summary>
        public ComponentVisionAnalysisTestType Type
        {
            get;
            set;
        }

        /// <summary>
        /// List of vision tests
        /// </summary>
        public List<ComponentVisionTest> VisionTests
        {
            get;
            set;
        }

        /// <summary>
        /// List of images that has been captured during the vision test (optional)
        /// </summary>
        public List<Image> Images
        {
            get;
            set;
        }

        /// <summary>
        /// Camera resources used for the vision test (optional)
        /// </summary>
        public List<Camera> Cameras
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the algorithm used to perform the vision test (optional)
        /// </summary>
        public string Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// Human readable comments describing the nature of the vision test (optional)
        /// </summary>
        public string Comments
        {
            get;
            set;
        }
    }
}
