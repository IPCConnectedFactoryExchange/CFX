using System.Collections.Generic;

namespace CFX.Structures
{
    /// <summary>
    /// A specialized type of Activity that occurs when one or several barcodes are read on a board.
    /// </summary>
    public class BarcodeReadingActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BarcodeReadingActivity()
        {
            ActivityName = "BARCODE READING";
            ValueAddType = ValueAddType.NonValueAdd;
        }

        /// <summary>
        /// The barcode, RFID, etc. that has been acquired by the scanner / reader.  If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of structures that identify each specific instance of production unit that arrived (if known).
        /// Could be individual units, or within a carrier, panel, etc. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
