using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Data for dome legacy cleaning equipment, which cannot be equipped with a messaging interface.
    /// However, such equipment can be extended with a stand-alone Cleaning Agent Concentration Management System 
    /// to take care of controlling and monitoring of the cleaning liquids.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CleaningManagementData : ProcessData
    {
        /// <summary>
        /// A list of readings / measurements that have been taken for this cleaning step
        /// </summary>
        public List<CleaningReading> Readings
        {
            get;
            set;
        }
    }
}
