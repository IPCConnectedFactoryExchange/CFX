using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CFX.Structures.Geometry;
using static System.Math;

namespace CFX.Structures.PCBInspection
{

    /// <summary>
    /// The geometry of a component (board, resistor, capacitor, pin, ...).
    /// </summary>
    public class GeometricObject : InspectionObject
    {
        /// <summary>
        /// X=Width, Y=Height, Z=Depth, in mm.
        /// </summary>
        [JsonProperty(Order = -2)]  // The property should come right after the name.
        public Vector3? Size { get; set; }

        /// <summary>
        /// The position in global coordinates, i.e. all position shifts and rotations of the
        /// parent objects (recursively) are factored in.
        /// Given in mm, as right handed coordinates.
        /// </summary>
        [JsonProperty(Order = -2)]
        public Vector3? Position { get; set; }

        /// <summary>
        /// The global rotation, i.e. all rotations of the parent objects (recursively) factored in.
        /// X=RotationAroundXAxis, Y=RotationAroundYAxis, Z=RotationAroundZAxis, in degrees [0..360]
        /// around the center of this object, right hand rule.
        /// Optional value. If missing in the recipe, then it is assumed to be (0.0, 0.0, 0.0).
        /// </summary>
        [JsonProperty(Order = -2)]
        public Vector3? Rotation { get; set; }

    }
}
