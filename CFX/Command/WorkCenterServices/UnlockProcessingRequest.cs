using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Command.WorkCenterServices
{
    /// <summary>
    /// Instructs a work center that a previously issued <see cref="LockProcessingRequest"/> has been 
    /// lifted, and production may resume at the work center.
    /// </summary>
    public class UnlockProcessingRequest
    {
    }
}
