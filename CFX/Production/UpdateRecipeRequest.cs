using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class UpdateRecipeRequest
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
    }
}
