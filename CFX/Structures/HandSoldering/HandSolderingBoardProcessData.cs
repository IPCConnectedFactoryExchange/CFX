using System;
using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Holds information of the board for the hand soldering process.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class HandSolderingBoardProcessData : ProcessData
    {
        /// <summary>
        /// The board id.
        /// </summary>
        public Guid BoardId { get; set; }

        /// <summary>
        /// The board name.
        /// </summary>
        public string BoardName { get; set; }

        /// <summary>
        /// The start of work time stamp.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// The end of work time stamp.
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// List of soldered points.
        /// </summary>
        public List<SolderPoint> SolderPoints { get; set; }

        /// <summary>
        /// Board telemetry data.
        /// </summary>
        public TelemetryData TelemetryData { get; set; }

        /// <summary>
        /// Result file – optional Information.
        /// </summary>
        public File File { get; set; }

        /// <summary>
        /// The board result.
        /// </summary>
        public HandSolderingResult Result { get; set; }

        /// <summary>
        /// The number of the order.
        /// </summary>
        public string OrderNumber { get; set; }
    }
}
