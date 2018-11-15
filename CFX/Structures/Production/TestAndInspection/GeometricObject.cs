using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CFX.Structures.Geometry;

namespace CFX.Structures.Production.TestAndInspection
{

  /// <summary>
  ///   The geometry of a component (board, resistor, capacitor, pin, ...).
  /// </summary>
  public class GeometricObject : InspectionObject
  {
    //TODO Discuss units. Would mm or rad [0..2Pi] be more appropriate?

    /// <summary> X=Width, Y=Height, Z=Depth, in µm. </summary>
    [JsonProperty (Order = -2)]  // The property should come right after the name.
    public Vector3? Size;

    /// <summary> Position of the center point of this object, relative to the center point of the parent object, in µm, as right handed coordinates. </summary>
    [JsonProperty (Order = -2)]
    public Vector3? Position;

    /// <summary> X=RotationAroundXAxis, Y=RotationAroundYAxis, Z=RotationAroundZAxis, in degrees [0..360] around the center of this object, right hand rule, optional. </summary>
    [JsonProperty (Order = -2)]
    public Vector3? Rotation;
    //TODO Only rotation around z-axis necessary?


    /// <summary>
    ///   The position in global coordinates, i.e. all position shifts and rotations of the
    ///   parent objects (recursively) are factored in.
    ///   Given in µm, as right handed coordinates.
    /// </summary>
    [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
    public Vector3 PositionGlobal
    {
      get
      {
        // Calculate via Parent-Object
        if (Parent is GeometricObject)
        {
          GeometricObject parent = Parent as GeometricObject;

          //TODO Drehrichtung, d.h. Vorzeichen klären.
          //TODO Cache rotation matrix.
          Matrix44 RX = Matrix44.CreateRotationX (parent.Rotation?.X ?? 0.0 * 2.0 * Math.PI / 360.0);
          Matrix44 RY = Matrix44.CreateRotationY (parent.Rotation?.Y ?? 0.0 * 2.0 * Math.PI / 360.0);
          Matrix44 RZ = Matrix44.CreateRotationZ (parent.Rotation?.Z ?? 0.0 * 2.0 * Math.PI / 360.0);

          Vector3 position = Position ?? Vector3.Zero;
          //position = RX * RY * RZ * position;  // Doesn't work this way, as we need an affine transformation with homogeneous coordinates.
          position = Vector3.Transform (position, RX * RY * RZ);
          position = position + parent.PositionGlobal;

          return position;
        }
        else  // Parent is a Panel/InspectionObject or null.
        {
          return Position ?? Vector3.Zero;
        }
        throw new NotImplementedException ();
      }
    }

    /// <summary>
    ///   The global rotation, i.e. all rotations of the parent objects (recursively) factored in.
    ///   X=RotationAroundXAxis, Y=RotationAroundYAxis, Z=RotationAroundZAxis, in degrees [0..360] around the center of this object, right hand rule.
    /// </summary>
    [JsonIgnore]  // A calculated property, so no need to serialize and transmit it.
    public Vector3 RotationGlobal
    {
      get
      {
        // Calculate via Parent-Object
        if (Parent is GeometricObject)
        {
          GeometricObject parent = Parent as GeometricObject;
          Vector3 rotation = Rotation ?? Vector3.Zero;
          rotation = rotation + parent.RotationGlobal;

          // Restrict the rotation values to the range 0..<360 (degrees).
          Vector3 vec360 = new Vector3 (360);
          // The modulo-operator may return negative values, so a simple "rotation % vec360" is not sufficient.
          rotation = ((rotation % vec360) + vec360) % vec360;

          return rotation;
        }
        else  // Parent is a Panel/InspectionObject or null.
        {
          return Rotation ?? Vector3.Zero;
        }
      }
    }
  }
}
