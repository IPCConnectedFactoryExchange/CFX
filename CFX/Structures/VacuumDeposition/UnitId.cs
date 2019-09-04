using System;

namespace CFX.Structures
{
    /// <summary>
    /// Structure representing work units.
    /// </summary>
    public class UnitId
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
        /// Unit Engineering Change Revision Level.
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
        /// Unique ID of Production Unit.
        /// </summary>
        public string UnitIdentifier
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
