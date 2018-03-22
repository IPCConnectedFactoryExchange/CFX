using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to send a named recipe to a process endpoint. The message
    /// includes details of the recipe, depending on the classification of the process. 
    /// The response indicates whether the recipe has been received correctly or not.
    /// </summary>
    public class UpdateRecipeRequest : CFXMessage
    {
        public UpdateRecipeRequest()
        {
            Overwrite = false;
        }

        /// <summary>
        /// If set to true, any existing Recipe at the Endpoint with the same name will be replaced by the Recipe
        /// provided in this request.  If set to False, the update request will not succeed if a Recipe with the same
        /// name exists at the Endpoint.
        /// </summary>
        public bool Overwrite
        {
            get;
            set;
        }

        /// <summary>
        /// The new Recipe to be sent to the Endpoint.
        /// </summary>
        public Recipe Recipe
        {
            get;
            set;
        }

        /// <summary>
        /// The reason for the update
        /// </summary>
        public RecipeModificationReason? Reason
        {
            get;
            set;
        }
    }
}
