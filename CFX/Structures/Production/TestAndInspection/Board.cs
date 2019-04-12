using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   A board typically is part of a (multi-)panel and may contain fiducials, components
  ///   (an even sub boards).
  ///   It is an inspection object itself, too (with feature on its own).
  /// </summary>
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Board : GeometricObject
  {
      /// <summary>
      /// This is a list of fiducials
      /// </summary>
      [JsonProperty(Order = 1)] // The children should come at the end.
      public List<Fiducial> Fiducials { get; set; }

    /// <summary>
    /// This is the list of components in the board definition
    /// </summary>
      [JsonProperty (Order = 1)]
    public List<Component> Components { get; set; }
        /// <summary> Usually empty, but it allows to have panels with n boards and m "sub-boards", even recursivly. </summary>
        [JsonProperty (Order = 1)]
    public List<Board> Boards;


    /// <summary>
    /// Validate if there is a detected defect in the result of the inspection
    /// </summary>
    [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
    public override bool IsDefect
    {
      get
      {
        if (base.IsDefect)
          return true;  // The inspection object itself is defect.

        // Check all children recursively.

        foreach (Fiducial fiducial in Fiducials ?? Enumerable.Empty<Fiducial> ())
        {
          if (fiducial.IsDefect)
            return true; // At least one fiducial is defect, so this inspection object is considered defect.
        }

        foreach (Component component in Components ?? Enumerable.Empty<Component> ())
        {
          if (component.IsDefect)
            return true; // At least one component is defect, so this inspection object is considered defect.
        }

        foreach (Board board in Boards ?? Enumerable.Empty<Board> ())
        {
          if (board.IsDefect)
            return true; // At least one board is defect, so this inspection object is considered defect.
        }

        return false; // No defect in any of our features or children.
      }
    }


    /// <summary> Restrict serialization to avoid confusion. </summary>
    public bool ShouldSerializeBoards ()
    {
      return ((Boards != null) && (Boards.Count > 0));
    }


    public override void UpdateParentReference (InspectionObject x_parent)
    {
      base.UpdateParentReference (x_parent);

      // Update all children.
      foreach (Fiducial fiducial in Fiducials ?? Enumerable.Empty<Fiducial> ())
        fiducial.UpdateParentReference (this);

      foreach (Component component in Components ?? Enumerable.Empty<Component> ())
        component.UpdateParentReference (this);

      foreach (Board board in Boards ?? Enumerable.Empty<Board> ())
        board.UpdateParentReference (this);
    }
  }

}
