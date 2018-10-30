using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to modify a generic configuration parameter of a process endpoint.
    /// Upon successful processing of this request, the endpoint should publish a <see cref="StationParametersModified"/> message in addition to the 
    /// <see cref="ModifyStationParametersResponse"/> message that it sends back to the requester.
    /// <code language="none">
    /// {
    ///   "NewParameters": [
    ///     {
    ///       "$type": "CFX.Structures.GenericParameter, CFX",
    ///       "Name": "Torque1",
    ///       "Value": "35.6"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ModifyStationParametersRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ModifyStationParametersRequest()
        {
            NewParameters = new List<Parameter>();
        }

        /// <summary>
        /// A list of the paramters to be modified.  The Parameter structure is a dynamic structure, 
        /// and may be of differing types depending on the type of endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Parameter> NewParameters
        {
            get;
            set;
        }
    }
}
