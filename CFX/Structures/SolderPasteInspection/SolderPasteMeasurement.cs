using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderPasteInspection
{
    public class SolderPasteMeasurement : Measurement
    {
        /// <summary>
        /// The specific component lead / pad related to this measurement (eg.  "R31.2", "C2.1")
        /// </summary>
        public string ComponentPad
        {
            get;
            set;
        }

        /// <summary>
        /// The x dimension (length) of the paste deposition.  Includes the expected deposition
        /// length in the ExpectedValue property.
        /// </summary>
        public NumericValue PasteXSize
        {
            get;
            set;
        }

        /// <summary>
        /// The y dimension (width) of the paste deposition.  Includes the expected deposition
        /// width in the ExpectedValue property.
        /// </summary>
        public NumericValue PasteYSize
        {
            get;
            set;
        }

        /// <summary>
        /// The x location of the center of the paste deposition relative to the center of the pad.
        /// </summary>
        public NumericValue PasteXOffset
        {
            get;
            set;
        }

        /// <summary>
        /// The y location of the center of the paste deposition relative to the center of the pad.
        /// </summary>
        public NumericValue PasteYOffset
        {
            get;
            set;
        }

        /// <summary>
        /// The height of the paste deposition.  Includes the expected deposition
        /// height in the ExpectedValue property.
        /// </summary>
        public NumericValue PasteHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The volume of the paste deposition.  Includes the expected deposition
        /// volume in the ExpectedValue property.
        /// </summary>
        public NumericValue PasteVolume
        {
            get;
            set;
        }

        /// <summary>
        /// An optional image of the deposit formatted in an acceptable MIME image format (JPG, PNG, etc.)
        /// </summary>
        public Image DepositImage
        {
            get;
            set;
        }
    }
}
