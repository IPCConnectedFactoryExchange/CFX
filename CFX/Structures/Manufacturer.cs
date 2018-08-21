using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a Manufacturer
    /// <code language="none">
    /// {
    ///     "UniqueIdentifier": "UID23890423",
    ///     "Name": "ACME"
    /// }
    /// </code>
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// The unique identifier of the Manufacturer
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the Manufacturer
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
