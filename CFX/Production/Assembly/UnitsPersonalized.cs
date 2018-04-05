using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when a configuration or assignment is made (example MAC Address) 
    /// <code language="none">
    /// {
    ///   "TransactionId": "e5cf340c-6858-4e26-893d-deae86bc09f1",
    ///   "PersonalizedUnits": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "Characteristics": [
    ///         {
    ///           "Name": "MAC Address",
    ///           "Value": "C0-15-B9-2D-0F-3B"
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "Characteristics": [
    ///         {
    ///           "Name": "MAC Address",
    ///           "Value": "C0-15-B9-2D-0F-3C"
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
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
