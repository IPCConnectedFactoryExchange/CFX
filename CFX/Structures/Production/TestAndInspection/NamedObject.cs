using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CFX.Structures.Production.TestAndInspection
{

  public class NamedObject
  {
    [JsonProperty (Order = -3)]  // The name should come at the very first.
    public String Name;          // "C1", "R1", "Fiducial_1", "Pin1"
  }

}
