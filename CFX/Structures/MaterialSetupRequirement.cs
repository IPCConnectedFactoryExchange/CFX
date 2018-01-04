using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class MaterialSetupRequirement
    {
        public MaterialSetupRequirement()
        {
            ApprovedAlternateParts = new List<string>();
            ApprovedManufacturerParts = new List<string>();
        }

        /// <summary>
        /// The position where the required material must be installed on the Endpoint (optional).  
        /// Where applicable, a dot (".") notation should be utilized to designate 
        /// specific positions.  Examples:  MODULE1.FRONT.Pos23, STAGE2.BANK1.Pos44, etc.
        /// </summary>
        public string Position
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the part that must be loaded at this position.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of approved alternate parts (internal part numbers) that may be substituted 
        /// for the primary part.
        /// </summary>
        public List<string> ApprovedAlternateParts
        {
            get;
            private set;
        }

        /// <summary>
        /// An optional list of specific manufacturer part numbers that must be utilzed.  When specified,
        /// a part will only be acceptable if both its internal part number matches the PartNumber property (or Alternates), 
        /// AND its manufacturer part number matches one of the parts specified in the ApprovedManufacturerParts property.
        /// 
        /// </summary>
        public List<string> ApprovedManufacturerParts
        {
            get;
            private set;
        }
    }
}
