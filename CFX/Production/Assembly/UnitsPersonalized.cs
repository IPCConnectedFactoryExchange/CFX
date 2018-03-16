using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    public class UnitsPersonalized : CFXMessage
    {
        public UnitsPersonalized()
        {
            PersonalizedUnits = new List<PersonalizedUnit>();
        }

        public Guid TransactionId
        {
            get;
            set;
        }

        public List<PersonalizedUnit> PersonalizedUnits
        {
            get;
            set;
        }
    }
}
