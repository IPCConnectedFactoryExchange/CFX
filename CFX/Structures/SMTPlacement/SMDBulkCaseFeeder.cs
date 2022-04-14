using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Describes an Bulk Case feeder.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class SMDBulkCaseFeeder : MaterialCarrier
    {
        /// <summary>
        /// The x dimension of each cell in this Bulk Case feeder
        /// </summary>
        public double CellDimensionX
        {
            get;
            set;
        }

        /// <summary>
        /// The y dimension of each cell in this Bulk Case feeder
        /// </summary>
        public double CellDimensionY
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the x axis in this Bulk Case feeder
        /// </summary>
        public int CellCountX
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the y axis in this Bulk Case feeder
        /// </summary>
        public int CellCountY
        {
            get;
            set;
        }

        /// <summary>
        /// The x offset between adjacent cells in this Bulk Case feeder
        /// </summary>
        public double CellPitchX
        {
            get;
            set;
        }

        /// <summary>
        /// The y offset between adjacent cells in this Bulk Case feeder
        /// </summary>
        public double CellPitchY
        {
            get;
            set;
        }
    }
}
