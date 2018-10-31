using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to modify the behaviour for this dedicated fault in such a way that the
    /// equoipment itself is not indicating the operator to handle this fault.
    /// Basically the fault should be handled remotly and no  operator should be guided by the equipment itself to handle
    /// this fault locally on the equipment. 
    /// <see cref="HandleFaultResponse"/> message that it sends back to the requester.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class HandleFaultRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HandleFaultRequest()
        {
        }

        /// <summary>
        /// A 128-bit unique identifier which uniquely identifier this specific 
        /// occurrence of the fault
        /// </summary>
        public Guid FaultOccurrenceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the fault should be handled remotely or not.
        /// If handled remotely, the red light should be off on the equipment (at least for this fault)
        /// </summary>
        public bool HandleRemote
        {
            get;
            set;
        }


    }
}
