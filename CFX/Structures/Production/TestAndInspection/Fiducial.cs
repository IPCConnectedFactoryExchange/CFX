using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   Fiducial mark for justification (position and orientation) of panels/boards.
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Fiducial : GeometricObject
  {
    public String Type;        // "Circle", "Rect"
  }

}
