using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// A class to represent the expected measurement results of an inspection process. 
    /// This information is tranferred within the Recipe.
    /// Typical example: solder paste inspection (SPI) expected values for the different dimensions
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class InspectionMeasurementExpected : Measurement
    {
        /// <summary>
        /// The expected or nominal dimension (length) of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double EX
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal dimension (length) of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double EY
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal height of the inspection object, expressed in millimeters (mm).
        /// This value conforms to the stencil thickness on the position where the aperture is located
        /// </summary>
        public double EZ
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal X position of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double PX
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal Y position of the inspection object, expressed in millimeters (mm).
        /// </summary>
        public double PY
        {
            get;
            set;
        }
        /// <summary>
        /// The expected area of the inspection object, expressed in square millimeters 
        /// </summary>
        public double EA
        {
            get;
            set;
        }
        /// <summary>
        /// The expected or nominal volume of the inspection object, expressed in milliliters (ml)
        /// </summary>
        public double EVol
        {
            get;
            set;
        }
        /// <summary>
        /// Area Ratio of the related Aperture (Area/WallArea)
        /// </summary>
        public double AR
        {
            get;
            set;
        }
    
        /// <summary>
        /// Rotation related information
        /// The counter-clockwise rotational offset on the X-Y plane (in degrees)
        /// This information is optional, if not available the angles are supposed to be zero
        /// </summary>
        public double? RXY
        {
            get;
            set;
        }

        /// <summary>
        /// Optional: List of vertices in case of a polygon shape (segments in CFX terms)
        /// </summary>
        public List<Segment> Vertices { get; set; }

    }
}
