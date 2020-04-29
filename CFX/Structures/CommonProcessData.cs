using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX;
using CFX.Structures.SolderPastePrinting;

namespace CFX.Structures
{
    /// <summary>
    /// Represents the base class for the updated Printer PCB process data
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CommonProcessData : ProcessData
    {
        public CommonProcessData()
        {

        }

        public SolderPastePrintingProcessData SolderPastePrintingProcessData { get; set; }
        public SolderPastePrintingPCBProcessData SolderPastePrintingPCBProcessData { get; set; }
    }

}
