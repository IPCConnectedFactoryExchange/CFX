using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// A process endpoint uses this message to send a data object that has been acquired
    /// for example from a sensor or a reading taken during processing of the unit. This
    /// data is typically used as a traceability record. Where no unit ID is provided, 
    /// the measurement is applicable to the process in terms of time only.
    /// </summary>
    public class ReadingsRecorded : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ReadingsRecorded()
        {
            Readings = new List<Reading>();
        }

        /// <summary>
        /// If the readings related to this message are associated with a work transaction, this property
        /// contains the Id of the transaction.
        /// </summary>
        public Guid? TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure providing a list of readings to be recorded.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Reading> Readings
        {
            get;
            set;
        }
    }
}
