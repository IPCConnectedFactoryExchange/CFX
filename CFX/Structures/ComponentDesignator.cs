using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Represents and identifies a particular component (instance of a part) on a production unit, or a particular aspect
    /// of a particular component, such as an individual pin of an electronic component.
    /// </summary>
    public class ComponentDesignator
    {
        public ComponentDesignator()
        {
            UnitPosition = null;
        }

        /// <summary>
        /// A dot (".") and comma (",") delimeted string identifying a particular component on a production unit.  
        /// 
        /// Examples:
        /// 
        /// C34
        /// U2.11  (component U2, Pin 11)
        /// U2.1-45 (component U2, Pins 1 to 45)
        /// U2.1,2 (component U2, Pins 1 and 2)
        /// </summary>
        public string ReferenceDesignator
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the related production unit
        /// </summary>
        public UnitPosition UnitPosition
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the designated component.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }
    }
}
