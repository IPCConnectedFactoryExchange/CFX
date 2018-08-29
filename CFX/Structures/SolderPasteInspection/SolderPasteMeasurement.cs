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
    }
}
