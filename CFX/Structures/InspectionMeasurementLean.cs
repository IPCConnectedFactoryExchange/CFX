using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// A class to represent the dynamic measurement results of an inspection process without the 
    /// overhead of the static properties which are already tranferred within the Recipe.
    /// The static properties are provide in the CFX.Structures.InspectionMeasurementTarget
    /// Typical example: solder paste inspection (SPI)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class InspectionMeasurementLean: Measurement
    {
        /// <summary>
        /// The x dimension (length) of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double X
        {
            get;
            set;
        }

        /// <summary>
        /// The x dimension (length) of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double Y
        {
            get;
            set;
        }

        /// <summary>
        /// The height of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double Z
        {
            get;
            set;
        }

        /// <summary>
        /// The x location of the center of the inspection object relative to the center of the pad.
        /// </summary>
        public double DX
        {
            get;
            set;
        }

        /// <summary>
        /// The y location of the center of the inspection object relative to the center of the pad.
        /// </summary>
        public double DY
        {
            get;
            set;
        }

        /// <summary>
        /// The volume of the inspection object, expressed in milliliters (ml)
        /// </summary>
        public double Vol
        {
            get;
            set;
        }
        /// <summary>
        /// The area of the inspection object, expressed in square millimeters 
        /// </summary>
        public double A
        {
            get;
            set;
        }
        
        /// <summary>
        /// An optional image of the deposit formatted in an acceptable MIME image format (JPG, PNG, etc.)
        /// </summary>
        public Image Image
        {
            get;
            set;
        }
    }
}
