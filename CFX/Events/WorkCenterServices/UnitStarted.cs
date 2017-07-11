using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX
{
    /// <summary>
    /// Indicates that work has begun on one or more production units at a particular work center.
    /// </summary>
    public class UnitStarted
    {
        public UnitStarted()
        {
            UnitTransactionID = Guid.NewGuid();
        }

        public Guid UnitTransactionID
        {
            get;
            set;
        }

        public string UnitIdentifier
        {
            get;
            set;
        }
    }
}
