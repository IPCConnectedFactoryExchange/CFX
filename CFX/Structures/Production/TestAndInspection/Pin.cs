using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   The pins of a component (typically two on resistores, many more on ICs).
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Pin : GeometricObject
  {
  }
}
