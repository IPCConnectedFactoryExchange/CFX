using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CFX.Utilities
{
    internal static class AppLog
    {
        public static void Error(string message)
        {
            Debug.WriteLine("ERROR:  " + message);
        }

        public static void Info(string message)
        {
            Debug.WriteLine("INFO:    " + message);
        }

        public static void Error(Exception ex)
        {
            Debug.WriteLine("ERROR:  " + ex.ToString());
        }
    }
}
