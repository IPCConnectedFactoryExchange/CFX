using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CFX.Structures.Geometry;

namespace CFX.Structures.PCBInspection
{

  /// <summary>
  ///   The root element for the CFX recipe export.
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Panel : InspectionObject
  {
    /// <summary>
    /// Name of the assembly variant. May be empty.
    /// </summary>
    public string Variant;
    /// <summary> Size of the panel (in µm). </summary>
    public Vector3? Size = null;

    /// <summary>
    /// The list of fiducials of this panel.
    /// (Only the top-level fiducials, not the fiducials of a board.)
    /// </summary>
    [JsonProperty(Order = 1)] // The children should come at the end.
    public List<Fiducial> Fiducials { get; set; }

    /// <summary>
    /// The list of boards, that are part of this panel.
    /// (Only the top-level boards, not the sub-boards of a top-level board.)
    /// </summary>
    [JsonProperty (Order = 1)]
    public List<Board> Boards { get; set; }

    /// <summary>
    /// List of components directly assigned to this panel, not those assigned to one of its boards.
    /// Usually empty (as a panel consist of n boards), but allows to omit boards and assign the components directly to the panel.
    /// </summary>
    [JsonProperty (Order = 1)]
    public List<Component> Components { get; set; }


    /// <summary>
    ///   Even if a panel is defective, one of its boards can still be (and typically will be) Ok. 
    /// </summary>
    [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
    public override bool IsDefect
    {
      get
      {
        if (IsRepaired)
          return false;  // The panel as a whole was repaired, so it is not a defect anymore.

        if (base.IsDefect)
          return true;  // The inspection object itself is defect.

        // Check all children recursively.

        foreach (Fiducial fiducial in Fiducials ?? Enumerable.Empty<Fiducial> ())
        {
          if (fiducial.IsDefect)
            return true; // At least one fiducial is defect, so this inspection object is considered defect.
        }

        foreach (Board board in Boards ?? Enumerable.Empty<Board> ())
        {
          if (board.IsDefect)
            return true; // At least one board is defect, so this inspection object is considered defect.
        }

        foreach (Component component in Components ?? Enumerable.Empty<Component> ())
        {
          if (component.IsDefect)
            return true; // At least one component is defect, so this inspection object is considered defect.
        }

        return false; // No defect in any of our features or children.
      }
    }


    /// Restrict serialization to avoid confusion.
    public bool ShouldSerializeComponents ()
    {
      return ((Components != null) && (Components.Count > 0));
    }
  }
}
