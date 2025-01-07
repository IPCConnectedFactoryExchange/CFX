using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Flux head information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class WaveFluxHead
    {
        /// <summary>
        /// 1 based sequence (1, 2, 3, ...)
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FluxHead"/> is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the process time reading value.
        /// </summary>
        public TimeSpan ProcessTimeReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the dose set value in %.
        /// </summary>
        public double DoseSetValue { get; set; }

        /// <summary>
        /// Gets or sets the dose reading point in %.
        /// </summary>
        public double DoseReadingPoint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [consumption measurement active] during the processing of the unit.
        /// </summary>
        public bool ConsumptionMeasurementActive { get; set; }

        /// <summary>
        /// Gets or sets the flux head1 axis1 consumption set value in ml.
        /// </summary>
        public double ConsumptionSetValue { get; set; }

        /// <summary>
        /// Gets or sets the flux head1 axis1 consumption reading point in ml.
        /// </summary>
        public double ConsumptionReadingPoint { get; set; }

        /// <summary>
        /// Gets or sets the active flux tank set value. 1 based (1, 2, ...)
        /// </summary>
        public int ActiveFluxTankSetValue { get; set; }

        /// <summary>
        /// Gets or sets the active flux tank reading point. 1 based (1, 2, ...)
        /// </summary>
        public int ActiveFluxTankReadingPoint { get; set; }

        /// <summary>
        /// Gets or sets the flux tank pressure set value in mbar.
        /// </summary>
        public int FluxTankPressureSetValue { get; set; }

        /// <summary>
        /// Gets or sets the flux tank pressure reading point in mbar.
        /// </summary>
        public int FluxTankPressureReadingPoint { get; set; }

        /// <summary>
        /// Gets or sets the flux traverse speed set value in mm/sec.
        /// </summary>
        public int FluxTraverseSpeedSetValue { get; set; }

        /// <summary>
        /// Gets or sets the flux traverse speed reading point in mm/sec.
        /// </summary>
        public int FluxTraverseSpeedReadingPoint { get; set; }
    }
}
