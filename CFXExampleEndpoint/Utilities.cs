using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CFXExampleEndpoint
{
    public class Utilities
    {
        public static string GetNextEndpointReceiveChannel()
        {
            int next = Process.GetProcessesByName("CFXExampleEndpoint").Length;
            string name = "CFXEndpoint" + next;
            return "amqp://localhost:5672," + name + "\r\n";
        }
    }
}
