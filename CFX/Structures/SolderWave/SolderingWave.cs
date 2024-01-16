using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class SolderingWave
    {
        /// <summary>
        /// Determines whether the stage (module) was during the processing active or not.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 1 based sequence (1, 2, 3, ...)
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the process time reading value.
        /// </summary>
        public TimeSpan ProcessTimeReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the number of revolutions set point.
        /// </summary>
        public double NumberOfRevolutionsSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the number of revolutions reading value.
        /// </summary>
        public double NumberOfRevolutionsReadingValue { get; set; }
    }
}
