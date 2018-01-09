using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderPastePrinting
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTSolderPastePrintingFaultType
    {
        SqueegeeError,
        PasteError,
    }
}
