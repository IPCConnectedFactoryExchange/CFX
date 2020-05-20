using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// All endpoints are obligated to publish a Heartbeast message on all
    /// Publish type no less than once every 5 minutes.  The <see cref="CFX.Transport.AmqpCFXEndpoint"/>
    /// class automatically performs this function for you when using the CFX SDK.
    /// You can adjust the frequency of the Heartbeat using the <see cref="CFX.Transport.AmqpCFXEndpoint.HeartbeatFrequency"/>
    /// to any value between 1 second and 5 minutes.  By default, the CFX SDK sends a Heartbeat once every 1 minute.
    /// <code language="none">
    /// {
    ///     "CFXHandle": "SMTPlus.Model_21232.SN23123",
    ///     "HeartbeatFrequency": "00:01:00"
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class Heartbeat : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint that is publishing the Heartbeat.
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of time to expect between Heartbeast messasges for this endpoint
        /// </summary>
        public TimeSpan HeartbeatFrequency
        {
            get;
            set;
        }
    }
}
