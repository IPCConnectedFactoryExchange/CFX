using System;
using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Holds hand soldering job information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class Job
    {
        /// <summary>
        /// The job name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The job id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// List of used devices for this job.
        /// </summary>
        public List<Device> Devices { get; set; }
    }
}