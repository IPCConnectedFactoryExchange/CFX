using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Represents an operator who performs a function
    /// </summary>
    public class Operator
    {
        public Operator()
        {
            ActorType = ActorType.Human;
        }

        /// <summary>
        /// An optional unique identifier for the Operator
        /// </summary>
        public string OperatorIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The nature of the operator
        /// </summary>
        public ActorType ActorType
        {
            get;
            set;
        }

        /// <summary>
        /// The Family Name of the Operator
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// The Given Name of the Operator
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// The Login Name for this Operator
        /// </summary>
        public string LoginName
        {
            get;
            set;
        }
    }
}
