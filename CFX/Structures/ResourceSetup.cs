using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the resources / sub-resources setup in an Endpoint.
    /// It may be used to model, among the others: feeder, table, nozzle changers and other 
    /// parts that may require traceable operations (i.e. maintenance)
    /// </summary>
    public class ResourceSetup
    {
        /// <summary>
        /// The barcode, RFID, or other unique identifier that is used to identify this machine / endpoint.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the endpoint to be used in GUIs or reporting
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
