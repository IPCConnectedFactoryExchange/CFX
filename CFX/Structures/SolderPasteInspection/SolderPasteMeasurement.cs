using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderPasteInspection
{
    /// <summary>
    /// Describes the results of a measurement that was made on a solder paste deposition.
    /// </summary>
    public class SolderPasteMeasurement : Measurement
    {
        /// <summary>
        /// The x dimension (length) of the paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double X
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal x dimension (length) required for this paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double EX
        {
            get;
            set;
        }

        /// <summary>
        /// The x dimension (length) of the paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double Y
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal x dimension (length) required for this paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double EY
        {
            get;
            set;
        }

        /// <summary>
        /// The height of the paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double Z
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal height required for this paste deposition, expressed in millimeters (mm).
        /// </summary>
        public double EZ
        {
            get;
            set;
        }

        /// <summary>
        /// The x location of the center of the paste deposition relative to the center of the pad.
        /// </summary>
        public double DX
        {
            get;
            set;
        }

        /// <summary>
        /// The y location of the center of the paste deposition relative to the center of the pad.
        /// </summary>
        public double DY
        {
            get;
            set;
        }

        /// <summary>
        /// The volume of the paste deposition, expressed in milliliters (ml)
        /// </summary>
        public double Vol
        {
            get;
            set;
        }

        /// <summary>
        /// The expected or nominal volume of the paste deposition, expressed in milliliters (ml)
        /// </summary>
        public double EVol
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
        /// <summary>
        /// The area of the paste deposition, expressed in square millimeters 
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double A
        {
            get;
            set;
        }
        /// <summary>
        /// The expected area of the paste deposition, expressed in square millimeters 
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double EA
        {
            get;
            set;
        }
        /// <summary>
        /// The position X value in millimeters (mm).
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PX
        {
            get;
            set;
        }
        /// <summary>
        /// The position X value in millimeters (mm).
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PY
        {
            get;
            set;
        }
        // Rotation related information
        // This information is optional, if not available the angles are supposed to be zero
        /// <summary>
        /// The counter-clockwise rotational offset on the X-Y plane (in degrees)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double? RXY
        {
            get;
            set;
        }
        /// <summary>
        /// Area Ratio of the related Aperture (Area/WallArea)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double AR
        {
            get;
            set;
        }

    }
}
