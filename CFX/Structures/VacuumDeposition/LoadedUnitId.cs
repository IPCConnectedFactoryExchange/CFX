using System;

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Dynamic structure base class representing work units.
    /// </summary>
    public class LoadedUnitId : UnitPosition
    {
        /// <summary>
        /// Unit assembly part number.
        /// </summary>
        public string AssyPN
        {
            get;
            set;
        }

        /// <summary>
        /// Unit engineering change revision level.
        /// </summary>
        public string ECRL
        {
            get;
            set;
        }

        /// <summary>
        /// Unit revision level.
        /// </summary>
        public string Rev
        {
            get;
            set;
        }

        /// <summary>
        /// Unit side.
        /// </summary>
        public string Side
        {
            get;
            set;
        }

        /// <summary>
        /// Unique ID of production unit.
        /// </summary>
        public string UnitId
        {
            get;
            set;
        }

        /// <summary>
        /// Unit work order number.
        /// </summary>
        public string WorkOrder
        {
            get;
            set;
        }
    }
}
