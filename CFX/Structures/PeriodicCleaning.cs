using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;
using Newtonsoft.Json;

namespace CFX.Structures
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class PeriodicCleaning
    {
        /// <summary>
        /// Periodic cleaning constructor
        public PeriodicCleaning()
        {

        }

        /// <summary>
        /// After how many Panels the Printer executes the cleaning process - nominal clean rate
        /// </summary>
        public int? CleanFrequency { get; set; }
        /// <summary>
        /// Clean mode - string to enable combination of values
        /// In a second stage, an enum could be defined
        /// </summary>
        public string CleanMode { get; set; }
            
        
    }
}
