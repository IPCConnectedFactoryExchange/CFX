using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate that a change has been made to a specified named recipe.
    /// </summary>
    public class RecipeModified : CFXMessage
    {
        /// <summary>
        /// The name of the recipe
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0”
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// The operator who performed the modification.
        /// </summary>
        public Operator ModifiedBy
        {
            get;
            set;
        }

        /// <summary>
        /// The reason for the modification.
        /// </summary>
        public RecipeModificationReason Reason
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
