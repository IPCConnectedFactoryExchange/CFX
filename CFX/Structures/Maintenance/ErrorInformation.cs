using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the errors of the 
    /// resources / sub-resources in an Endpoint.
    /// It is used in maintenance context
    /// </summary>
    public class ErrorInformation
    {
        /// <summary>
        /// Name of the error(text output)
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// When available, the error code from the machine
        /// </summary>
        public int ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the error has been raised
        /// </summary>
        public DateTime? OccurrenceTime
        {
            get;
            set;
        }
    }
}
