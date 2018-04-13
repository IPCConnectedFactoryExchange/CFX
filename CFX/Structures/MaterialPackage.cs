using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a specific, single handling unit of a particular material, such as a reel of SMT parts,
    /// a bag of parts, bin of parts, etc.
    /// </summary>
    public class MaterialPackage
    {
        public MaterialPackage()
        {
        }

        /// <summary>
        /// The Unique identifier of the material package (barcode/RFID that identifies
        /// this specific material package.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the material package
        /// </summary>
        public string InternalPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of parts or material contained within this material package.
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }
    }
}
