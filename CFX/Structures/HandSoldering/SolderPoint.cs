using System;
using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Solder point information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SolderPoint
    {
        /// <summary>
        /// The solder point name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The component of the solder point.
        /// </summary>
        public Component Component { get; set; }

        /// <summary>
        /// The used materials.
        /// </summary>
        public List<Material> Materials { get; set; }

        /// <summary>
        /// The start of work time stamp.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// The end of work time stamp.
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// The position of the solder point.
        /// </summary>
        public SolderPointPosition SetSolderingPosition{ get; set; }

        /// <summary>
        /// The used position of the solder task.
        /// </summary>
        public SolderPointPosition ReadSolderingPosition { get; set; }

        /// <summary>
        /// The result picture of the solder point.
        /// </summary>
        public File ResultPicture { get; set; }

        /// <summary>
        /// The solder point result.
        /// </summary>
        public HandSolderingResult Result { get; set; }
    }
}
