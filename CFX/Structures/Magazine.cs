using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Structure that contains information related to a magazine.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class Magazine
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Magazine()
        {

        }
        /// <summary>
        /// Barcode of a magazine, required to identify the magazine.
        /// </summary>
        public string MagazineId
        {
            get;
            set;
        }

        /// <summary>
        /// List of Hermes units (i.e. Boards) contained in the magazine.
        /// </summary>
        public List<HermesUnit> HermesUnits
        {
            get;
            set;
        }
    }
}
