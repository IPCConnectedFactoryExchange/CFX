using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class SolderingWave
    {
        public bool Active { get; set; }

        /// <summary>
        /// 1 based sequence (1, 2, 3, ...)
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the process time reading value.
        /// </summary>
        public TimeSpan ProcessTimeReadingValue { get; set; }

        public double NumberOfRevolutionsSetpoint { get; set; }

        public double NumberOfRevolutionsReadingValue { get; set; }
    }
}
