using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    public class GetRequiredSetupResponse : CFXMessage
    {
        public GetRequiredSetupResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the recipe associated with the required setup.
        /// </summary>
        public string RecipeName
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
