using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a tool that is used in production
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// The unique identifier of the Tool (barcode, RFID, etc.)
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the tool
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
