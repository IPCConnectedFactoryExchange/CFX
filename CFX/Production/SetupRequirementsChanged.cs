using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// Indicates that the setup requirements of a particular Endpoint have changed.  If the Lane and Stage
    /// properties are left empty, the setup requirements of the entire Endpoint have been impacted.  Otherwise,
    /// only the specified Lane and/or Stage is impacted.
    /// </summary>
    public class SetupRequirementsChanged : CFXMessage
    {
        /// <summary>
        /// An optional property designating the affected Lane.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the affected Stage.
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
