using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Utilities
{
    static class EnvironmentHelper
    {
        public static string GetMachineName()
        {
            return Environment.GetEnvironmentVariable("COMPUTERNAME");
        }
    }
}
