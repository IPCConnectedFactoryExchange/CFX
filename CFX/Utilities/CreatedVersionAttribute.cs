using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Utilities
{
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
        public CreatedVersionAttribute(string createdVersion)
        {
            CreatedVersion = createdVersion;
        }

        public string CreatedVersion
        {
            get;
            set;
        }
    }
}
