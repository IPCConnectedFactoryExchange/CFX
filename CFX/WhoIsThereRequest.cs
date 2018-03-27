using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to discover all of the other endpoints participating in this CFX network, 
    /// and their capabilities. All other CFX endpoints must then respond to this broadcast, providing
    /// information about themselves.  The response provides basic information about the endpoint, 
    /// including its CFX Handle and network hostname / address.
    /// <code language="none">
    /// {}
    /// </code>
    ///</summary>
    public class WhoIsThereRequest : CFXMessage
    {
    }
}
