using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Indicates the result of a validation that was performed on a given production unit (typically by a line or factory level control system)
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ValidationResult()
        {
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6). 
        /// </summary>
        public int PositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the overall result of the validation
        /// </summary>
        public ValidationStatus Result
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates an endpoint-specific failure code
        /// </summary>
        public int FailureCode
        {
            get;
            set;
        }

        /// <summary>
        /// A human readable message describing the result of the validation
        /// </summary>
        public string Message
        {
            get;
            set;
        }
    }
}
