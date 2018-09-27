using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a single, specific tool that must be setup a particular process endpoint to execute
    /// a particular process.  Includes the part number of the tool, along with the 
    /// specific location where the tool loaded (when applicable).
    /// </summary>
    public class ToolSetupRequirement
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ToolSetupRequirement()
        {
        }

        /// <summary>
        /// The position where the required tool must be installed on the Endpoint (optional).  
        /// Where applicable, a dot (".") notation should be utilized to designate 
        /// specific positions.  Examples:  MODULE1.BEAM1.HEADPOS2, MODULE1.NEST3.NOZZLESLOT4, etc.
        /// </summary>
        public string Position
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the tool that must be loaded at this position.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Optional.  If a very specific tool is required (specific serial number), the unique identifier
        /// of that specific tool will be provided by this property.  If any tool of a certain part number
        /// may be user, this property will be null.
        /// </summary>
        public string ToolIdentifier
        {
            get;
            set;
        }
    }
}
