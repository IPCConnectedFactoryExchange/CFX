using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.ReworkAndRepair
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Sent by a process endpoint when one or more units have been reworked or repaird.  Includes outcome information,
    /// as well as a detailed report of the repair(s) performed.  If defects or faulty test results (symptoms) were
    /// previously reported for these production unit(s), this message also relates the repairs performed back to these
    /// inspection/test results.
    /// <para>  </para>
    /// <para>Generic Inspection Example (2 Circuit PCB Panel inspected via AOI):</para>
    /// <para>  </para>
    /// <code language="none">
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class UnitsRepaired : CFXMessage
    {
        ///<summary>
        /// Unit inspected default constructor, used to model all the different inspection options
        /// </summary>
        public UnitsRepaired()
        {
            RepairedUnits = new List<RepairedUnit>();
            RepairOperator = new Operator();
        }

        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the repair(s), or operator of the automated equipment that performed the repairs (optional)
        /// </summary>
        public Operator RepairOperator
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were repaired, along with the details of those repairs, 
        /// and the results.
        /// </summary>
        public List<RepairedUnit> RepairedUnits
        {
            get;
            set;
        }
    }
}
