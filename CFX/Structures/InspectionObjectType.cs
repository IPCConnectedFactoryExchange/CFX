using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    // <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    ///Provide information of the inspection object type
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InspectionObjectType
    {
        /// <summary>
        /// Unknown object
        /// </summary>
        Unknown,
        /// <summary>
        /// General object not specifically modelled in this enumeration
        /// </summary>
        General,
        /// <summary>
        /// Printed Circuit Board with 1:n Unit(s)
        /// </summary>
        PCB,
        /// <summary>
        /// CFX Unit 
        /// </summary>
        Unit,
        /// <summary>
        /// Fiducial of the unit inspected
        /// </summary>
        Fiducial,
        /// <summary>
        /// Barcode, 1D, 2D
        /// </summary>
        Barcode,
        /// <summary>
        /// Component on a unit
        /// </summary>
        Component,
        /// <summary>
        /// Pin of a given component
        /// </summary>
        Pin,
        /// <summary>
        /// 2D PCB location
        /// </summary>
        Pad,
        /// <summary>
        /// Solder deposit
        /// </summary>
        SolderDeposit
    }
}
