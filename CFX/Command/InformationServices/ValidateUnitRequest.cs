using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Command.InformationServices
{
    /// <summary>
    /// Allows a device to validate with a factory-level system (such as an MES system)
    /// that a particular production unit is able to be processed at a particular work center.
    /// This will typically includes a variety of validations, such as route validation (ensuring
    /// that a unit has completed all necessary steps prior to this operation), unit status validation
    /// (ensuring that a unit is not in a failed condition, or contains open defects), etc.
    /// </summary>
    public class ValidateUnitRequest
    {
    }
}
