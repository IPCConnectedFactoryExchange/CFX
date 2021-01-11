using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Utilities
{
    /// <summary>
    /// An attribute that may be applied to classes, properties, enumerations, and events indicating the version of CFX where the item was first introduced.
    /// If an item has no attribute, it may be assumed that the item was introduced in the first version of CFX ("1.0")
    /// </summary>
    [AttributeUsage(
       AttributeTargets.Class |
       AttributeTargets.Field |
       AttributeTargets.Method |
       AttributeTargets.Property |
       AttributeTargets.Interface |
       AttributeTargets.Enum,
       AllowMultiple = true)]
    public class CreatedVersionAttribute : System.Attribute
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="createdVersion"></param>
        public CreatedVersionAttribute(string createdVersion)
        {
            CreatedVersion = createdVersion;
        }

        /// <summary>
        /// The version of CFX where this item was first introduced.
        /// </summary>
        public string CreatedVersion
        {
            get;
            set;
        }
    }
}
