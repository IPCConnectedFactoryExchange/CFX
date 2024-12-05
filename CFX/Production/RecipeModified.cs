using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to indicate that a change has been made to a specified named recipe.
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE3234",
    ///   "Revision": "D",
    ///   "ModifiedBy": {
    ///     "OperatorIdentifier": "95739c63-7e59-481b-a597-627cb843c8f4",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   },
    ///   "Reason": "PositionalCorrection",
    ///   "Notes": null
    /// }
    /// </code>
    /// </summary>
    public class RecipeModified : CFXMessage
    {
        /// <summary>
        /// The name of the recipe (may include full path, if applicable)
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// Version number, e.g. “2.0” (Optional)
        /// </summary>
        public string Revision
        {
            get;
            set;
        }

        /// <summary>
        /// The operator who performed the modification. (optional)
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

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// Identifies the Work Order (or Batch) that is related to the modified recipe.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }
    }
}
