using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the verification of the 
    /// resources / sub-resources in an Endpoint.
    /// It may be used to model the verification results on  
    /// parts that may require traceable operations (i.e. maintenance)
    /// </summary>
    public class VerificationInformation
    {
        /// <summary>
        /// Name of the verification
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the performed verification.
        /// </summary>
        public OperationStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// The value of the performed verification.
        /// </summary>
        public double? Value
        {
            get;
            set;
        }

        /// <summary>
        /// The unit of measure of the performed verification (if applicable)
        /// </summary>
        public string UnitOfMeasure
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the verification that is performed on this resource / machine.
        /// </summary>
        public VerificationType Type
        {
            get;
            set;
        }

        /// <summary>
        /// If the verification is valid or should be ignored bay the receiving system. Default (i.e. null) = true
        /// </summary>
        public bool? IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// The last time when the verification has been executed
        /// </summary>
        public DateTime? LastExecution
        {
            get;
            set;
        }
        /// <summary>
        /// Free text for additional comment on the performed verification, if required
        /// </summary>
        public string Comment
        {
            get;
            set;
        }
    }
}
