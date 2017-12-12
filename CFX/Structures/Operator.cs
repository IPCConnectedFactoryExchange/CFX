using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class Operator
    {
        public Operator()
        {
            ActorType = ActorType.Human;
        }

        /// <summary>
        /// An optional unique identifier for the Operator
        /// </summary>
        public Guid? OperatorIdentifier
        {
            get;
            set;
        }

        public ActorType ActorType
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LoginName
        {
            get;
            set;
        }
    }
}
