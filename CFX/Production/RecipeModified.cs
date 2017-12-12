using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class RecipeModified : CFXMessage
    {
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the user who performed the modification.
        /// </summary>
        public Operator ModifiedBy
        {
            get;
            set;
        }

        /// <summary>
        /// The reason for the modification.
        /// </summary>
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// Any additional notes provided by the user who performed the modification.
        /// </summary>
        public string Notes
        {
            get;
            set;
        }
    }
}
