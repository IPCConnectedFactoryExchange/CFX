using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Represents the base class for the updated Printer recipe data
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CommonRecipeData : ProcessData
    {
       public CommonRecipeData()
       {

       }
        /// <summary>
        /// Represents the instance of a SolderPastePrintingProcessData to be added to the request message(s)
        /// </summary>
        public SolderPastePrintingProcessData SolderPastePrintingProcessData { get; set; }

    }
}
