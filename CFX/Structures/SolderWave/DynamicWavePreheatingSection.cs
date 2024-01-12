using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// Dynamic preheating section information.
    /// </summary>
    public class DynamicWavePreheatingSection
    {
        /// <summary>
        /// 1 based sequence (1, 2, 3, ...)
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [top preheat section1 active].
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the preheating sections.
        /// </summary>
        public List<WavePreheatingSection> PreheatingSections { get; set; }
    }
}
