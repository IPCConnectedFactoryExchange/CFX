using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// <para>** NOTE: ADDED in CFX 1.3 **</para>
/// An enumeration indicating the type of verification that can be executed during the process (i.e. maintenance)
/// </summary>
namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// Supported verification types
    /// </summary>
    public enum VerificationType
    {
        /// <summary>
        /// General verification of the machine
        /// </summary>    
        General,
        /// <summary>
        /// Unknown verification type
        /// </summary>
        Unkwnown,
        /// <summary>
        /// Verification of the head in the machine
        /// </summary>
        HeadVerification,
        /// <summary>
        /// Verification of the camera in the machine
        /// </summary>
        CameraVerification,
        /// <summary>
        /// Verification of the camera in the head
        /// </summary>
        HeadCameraVerification,
        /// <summary>
        /// Verification of the nozzle
        /// </summary>
        NozzleVerification
    }

}
