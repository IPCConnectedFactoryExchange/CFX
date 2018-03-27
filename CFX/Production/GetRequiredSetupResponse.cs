using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Response from a process endpoint to a request to obtain the setup requirements of the active recipe.
    /// The response lists the required materials and tools, along with the locations where 
    /// the materials/tools must be loaded.
    /// </summary>
    public class GetRequiredSetupResponse : CFXMessage
    {
        public GetRequiredSetupResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// Result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the recipe associated with the required setup.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        public string RecipeRevision
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Lane associated with this setup.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Stage associated with this setup.
        /// </summary>
        public string Stage
        {
            get;
            set;
        }

        public StationSetupRequirements SetupRequirements
        {
            get;
            set;
        }
    }
}
