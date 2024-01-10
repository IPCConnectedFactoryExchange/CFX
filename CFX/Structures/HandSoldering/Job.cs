using System;
using System.Collections.Generic;

namespace CFX.Structures.HandSoldering
{
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