using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Describes the results of repairs performed on a single production unit.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class RepairedUnit
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RepairedUnit()
        {
            Repairs = new List<Repair>();
            OverallResult = RepairResult.RepairSuccessful;
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard)
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the repairs performed on this unit
        /// </summary>
        public RepairResult OverallResult
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the Repairs performed, along with the results
        /// </summary>
        public List<Repair> Repairs
        {
            get;
            set;
        }
    }
}
