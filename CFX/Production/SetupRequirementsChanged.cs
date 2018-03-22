using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    /// <summary>
    /// Sent whenever the setup requirement of materials, tools, etc. are changed for any reason at a process endpoint. 
    /// This message contains a detailed listing of the required items, and their designated positions. 
    /// This message is typically used for example, whenever a new recipe is activated which requires a different setup.
    /// If the Lane and Stage properties are left empty, the setup requirements of the entire Endpoint have been impacted.
    /// Otherwise, only the specified Lane and/or Stage is impacted.
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
