using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Sent from a Hermes endpoint to request magazine data
    /// <code language="none">
    /// {
    ///   "MagazineId": "ID12345"
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class GetMagazineDataRequest : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetMagazineDataRequest()
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
    }
}
