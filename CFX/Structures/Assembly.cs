using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Dynamic structure base class describing an assembly (or sub-assebmly) that is built or purchased in a production environment.
    /// </summary>
    public class Assembly
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Assembly()
        {
        }

        /// <summary>
        /// The internal part number of the assembly
        /// </summary>
        public string InternalPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The revision of the assembly
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the manufacturer of the assembly
        /// </summary>
        public string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the original manufacturer of the assembly
        /// </summary>
        public string ManufacturerPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the supplier from whom the assembly was purchased / supplied.
        /// </summary>
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the supplier or vendor of the assembly
        /// </summary>
        public string VendorPartNumber
        {
            get;
            set;
        }
    }
}
