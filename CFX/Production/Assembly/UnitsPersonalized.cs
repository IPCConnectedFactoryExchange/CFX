using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when a configuration or assignment is made (example MAC Address) 
    /// </summary>
    public class UnitsPersonalized : CFXMessage
    {
        public UnitsPersonalized()
        {
            PersonalizedUnits = new List<PersonalizedUnit>();
        }

        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of production units that have been personalized, including
        /// the personalization characteristics of each.
        /// </summary>
        public List<PersonalizedUnit> PersonalizedUnits
        {
            get;
            set;
        }
    }
}
