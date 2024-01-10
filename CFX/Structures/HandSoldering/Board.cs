using System;
using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
    public class Board
    {
        /// <summary>
        /// The board name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The start of work time stamp.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// The end of work time stamp.
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// The duration of work in seconds.
        /// </summary>
        public int Duration { get; set; }

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
    }
}
