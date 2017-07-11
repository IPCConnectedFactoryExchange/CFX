using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX
{
    /// <summary>
    /// A CFX message that is transmitted periodically by all endpoints participating in a CFX mesh.
    /// The message is used to signal to the CFX mesh that the endpoint is online ane running.
    /// </summary>
    public class Heartbeat
    {
        /// <summary>
        /// The amount of time that is expected to ellapse between <see cref="Heartbeat"/> messages for this endpoint.
        /// </summary>
        public TimeSpan ExpectedInterval
        {
            get;
            set;
        }
    }
}
