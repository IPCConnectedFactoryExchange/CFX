using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CFX.Structures.PCBInspection
{

  /// <summary>
  ///   Fiducial mark for justification (position and orientation) of panels/boards.
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Fiducial : GeometricObject
  {
    /// <summary>
    /// Type of the fiducial, like "Circle" or "Rect".
    /// </summary>
    public String Type { get; set; }
  }

}
