using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Table (also know as change over table) resource in an Endpoint's setup.
    /// It may have a lifecycle independent from the Endpoint where it is located (e.g. maintenance operations)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class SMTTable : ResourceInformation
    {
       
    }
}
