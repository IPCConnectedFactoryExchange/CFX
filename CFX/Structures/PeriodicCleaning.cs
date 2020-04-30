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
        PeriodicCleaning()
        {

        }

        /// <summary>
        /// After how many Panels the Printer executes the cleaning process - nominal clean rate
        /// </summary>
        public int? CleanFrequency { get; set; }
        /// <summary>
        /// Clean mode 
        /// </summary>
        public SMTStencilCleanMode CleanMode { get; set; }
            
        
    }
}
