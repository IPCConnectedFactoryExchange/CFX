using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CFX.Structures.Geometry;

namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   The root element for the CFX recipe export.
  /// </summary>
  [JsonConverter (typeof (Panel.Converter))]
  [JsonObject (ItemNullValueHandling = NullValueHandling.Ignore)]
  public class Panel : InspectionObject
  {
    /// <summary> Name of the assembly variant. May be empty. </summary>
    public string Variant;
    /// <summary> Size of the panel (in µm). </summary>
    public Vector3? Size = null;

    [JsonProperty (Order = 1)]  // The children should come at the end.
    public List<Fiducial> Fiducials;
    [JsonProperty (Order = 1)]
    public List<Board> Boards;

    /// <summary> Usually empty (a panel consist of n boards), but allows to omit boards and assign the components directly to the panel. </summary>
    [JsonProperty (Order = 1)]
    public List<Component> Components;


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


    public override void UpdateParentReference (InspectionObject x_parent)
    {
      base.UpdateParentReference (x_parent);

      // Update all children.
      foreach (Fiducial fiducial in Fiducials ?? Enumerable.Empty<Fiducial> ())
        fiducial.UpdateParentReference (this);

      foreach (Board board in Boards ?? Enumerable.Empty<Board> ())
        board.UpdateParentReference (this);

      foreach (Component component in Components ?? Enumerable.Empty<Component> ())
        component.UpdateParentReference (this);
    }

    /// <summary>
    ///   A custom JSON-converter to correctly update all Parent-references after deserialization.
    /// </summary>
    class Converter : JsonConverter
    {
      public override bool CanConvert (Type objectType)
      {
        return objectType == typeof (Panel);
      }

      public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        Panel panel = new Panel ();

        JToken jToken = JToken.Load (reader);
        serializer.Populate (jToken.CreateReader (), panel);

        panel.UpdateParentReference (null);

        return panel;
      }

      /// <summary> For writing the default serialization is used. </summary>
      public override bool CanWrite
      {
        get
        {
          return false;
        }
      }
      public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
      {
        throw new NotImplementedException ();
      }
    }

  }

}
