using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Provides recipe information of a given Unit. The units is uniquely identified by the UnitPositionNumber
    /// Rules to generate the UnitPositionNumber are described in the CFX documentation
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class RecipeUnit
    {
        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard)
        /// </summary>
        public int UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Optional name of the Unit
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of child object which are to be inspected
        /// </summary>
        public List<InspectionObject> ChildObjects { get; set; }
    }
}
