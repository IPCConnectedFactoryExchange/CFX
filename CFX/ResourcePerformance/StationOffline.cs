using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when it is about to transition to a state where it is not 
    /// possible for further communication, for example when the endpoint is powered down, 
    /// reset, put into maintenance mode, or simply set off-line.
    /// <code language="none">
    /// {}
    /// </code>
    /// </summary>
    public class StationOffline : CFXMessage
    {
    }
}
