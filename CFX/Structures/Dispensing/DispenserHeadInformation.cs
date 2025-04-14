using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures.SMTPlacement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Dispensing
{
  /// <summary>
  /// Describes a head for an endpoint that is a dispensing machine.
  /// </summary>
  public class DispenserHeadInformation : HeadInformation
  {
    /// <summary>
    /// Information about the dispensing valves mounted on the head
    /// </summary>
    public List<DispenserValveInformation> Valves
    {
      get;
      set;
    }
  }
}
