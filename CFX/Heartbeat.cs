using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

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

        /// <summary>
        /// Any faults currently active on this endpoint.  Faults should be repeated here until cleared. 
        /// Leaving this parameter as null means that active faults are not known.  Setting it to an
        /// empty List implies positive knowledge that there are no active faults.
        /// </summary>
        public List<Fault> ActiveFaults
        {
            get;
            set;
        }

        /// <summary>
        /// Any recipes currently active on this endpoint.  Recipes may be specified either using
        /// their identifiers or by including recipe details such as expected cycle times depending
        /// on what information the endpoing is able to communicate.
        ///
        /// Leaving this parameter as null means that active recipes are not known.  Setting it to an
        /// empty List implies positive knowledge that there are no active recipes.
        ///
        /// Multiple recipes may be active at once on a given endpoint.
        /// </summary>
        public List<ActiveRecipe> ActiveRecipes
        {
            get;
            set;
        }
    }
}
