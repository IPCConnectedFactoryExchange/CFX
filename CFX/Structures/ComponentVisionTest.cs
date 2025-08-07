using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a vision test of a component
    /// </summary>
    public class ComponentVisionTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentVisionTest()
        {
        }

        /// <summary>
        /// If of the measured information
        /// </summary>
        public string InformationId
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// The type of the vision test
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public ComponentVisionTestType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Vision expected value
        /// </summary>
        public double ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Vision measured value
        /// </summary>
        public double MeasuredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum vision measure tolerance
        /// </summary>
        public double ToleranceMin
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum vision measure tolerance
        /// </summary>
        public double ToleranceMax
        {
            get;
            set;
        }

        /// <summary>
        /// Unit used for the Expected value, the Mesasured value, and the Tolerances
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
        
        /// <summary>
        /// Result of the vision test (true if OK)
        /// </summary>
        public Boolean Result
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// List of images that has been captured during the vision test (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public List<Image> Images
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// Camera resources used for the vision test (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public List<Camera> Cameras
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// Name of the algorithm used to perform the vision test (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public string Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// Human readable comments describing the nature of the vision test (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public string Comments
        {
            get;
            set;
        }
    }
}
