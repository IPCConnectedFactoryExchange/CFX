using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to request a process endpoint for the details of a named
    /// recipe. The response includes details of the recipe, depending on the 
    /// classification of the process.
    /// </summary>
    public class GetRecipeResponse : CFXMessage
    {
        public GetRecipeResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The recipe
        /// </summary>
        public Recipe Recipe
        {
            get;
            set;
        }
    }
}
