using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   A component as a resistor, capacitor, IC, ...
  ///   Typically has (two or more) pins (as its "children").
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Component : GeometricObject
  {
    //TODO Maybe use "Type" (resistor, capacitor, diode) and "Package" instead?
    public String Type;        // "C1206", "R1206", "TO252AA"
    public String Group;       // "Capacitor", "Resistor", "DPAK"

    [JsonProperty (Order = 1)]   // The children should come at the end.
    public List<Pin> Pins;


    [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
    public override bool IsDefect
    {
      get
      {
        if (base.IsDefect)
          return true;  // The inspection object itself is defect.

        // Check all children recursively.

        foreach (Pin pin in Pins ?? Enumerable.Empty<Pin> ())
        {
          if (pin.IsDefect)
            return true; // At least one fiducial is defect, so this inspection object is considered defect.
        }

        return false; // No defect in any of our features or pins.
      }
    }


    public override void UpdateParentReference (InspectionObject x_parent)
    {
      base.UpdateParentReference (x_parent);

      // Update all children.
      foreach (Pin pin in Pins ?? Enumerable.Empty<Pin> ())
      {
        pin.UpdateParentReference (this);
      }
    }
  }

}
