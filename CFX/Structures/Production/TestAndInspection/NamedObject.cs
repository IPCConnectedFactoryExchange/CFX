using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  /// Definition of a named object which can be identified with a name
  /// </summary>
  public class NamedObject
  {
    /// <summary>
    /// The name of the named object like "C1", "R1", "Fiducial_1", "Pin1"
    /// </summary>
    [JsonProperty (Order = -3)]  // The name should come at the very first.
    public String Name { get; set; }          // "C1", "R1", "Fiducial_1", "Pin1"
    }

}
