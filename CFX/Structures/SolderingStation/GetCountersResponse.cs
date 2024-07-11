using CFX.Structures;
using CFX.Structures.SolderingStation;
using CFX.Structures.SolderingStation.Identification;
using Newtonsoft.Json;

namespace CFX
{

    /// <summary>
    /// Allows any CFX endpoint to request the counters of a specified single endpoint's tool. 
    /// <para></para>
    /// Generic example:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": 
    ///   {
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetCountersResponse : CFXMessage
    {
        /// <summary>
        /// Global or Partial Counters
        /// </summary>
        public CountersType Type;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetCountersResponse() : base()
        {
            Type = CountersType.GLOBAL;
            Global_Counters = new GlobalCounters();
            Partial_Counters = new PartialCounters();
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
        /// Dynamic structure that describes the details of requested object.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public GlobalCounters Global_Counters
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure that describes the details of requested object.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public PartialCounters Partial_Counters
        {
            get;
            set;
        }
    }
}
