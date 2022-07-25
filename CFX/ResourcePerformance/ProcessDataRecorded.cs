using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures.Cleaning;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    ///Cleaning Agent needs to report the status of the cleaning liquid regularly 
    ///as well as an alarm if certain values go out of the allowable range
    /// <code language="none">
    /// {
    ///   "ProcessData": {
    ///     "$type": "CFX.Structures.Cleaning.CleaningManagementData, CFX",
    ///     "Readings": [
    ///       {
    ///         "ReadingType": "TemperatureAverage",
    ///         "ReadingValue": 25.0
    ///       },
    ///       {
    ///         "ReadingType": "DIWaterVolumeAdd",
    ///         "ReadingValue": 1.5
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    ///</summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ProcessDataRecorded : CFXMessage
    {
        /// <summary>
        /// Process data recorded
        /// </summary>
        public ProcessData ProcessData
        {
            get;
            set;
        }
    }
}
