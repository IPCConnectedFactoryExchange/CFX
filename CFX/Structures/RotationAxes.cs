using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Rotation axis of the resource, typically the head in an Endpoint.
    /// It may have a meaning for the lifecycle of the resource, which may be independent
    /// from the Endpoint where it is located (e.g. maintenance operations)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class RotationAxis : ResourceInformation
    {
        
    }
}
