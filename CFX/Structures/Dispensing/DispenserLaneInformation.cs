using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Dispensing
{
  /// <summary>
  /// Describes a lane for an endpoint that is an dispensing machine.
  /// </summary>
  public class DispenserLaneInformation
  {
    /// <summary>
    /// The lane number.  Corresponds with Lane property in production messages.
    /// </summary>
    public int? LaneNumber
    {
      get;
      set;
    }

    /// <summary>
    /// The friendly name of this lane.
    /// </summary>
    public string LaneName
    {
      get;
      set;
    }

    /// <summary>
    /// The maximum and minimum dimensions that a PCB panel or fixture must conform
    /// to in order to be processed by this lane.
    /// </summary>
    public DimensionalConstraints SupportedPCBDimensions
    {
      get;
      set;
    }
  }
}
