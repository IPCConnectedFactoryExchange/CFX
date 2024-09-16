using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Conveyor resource in an Endpoint. It may have a lifecycle independent
    /// from the Endpoint where it is located (e.g. maintenance operations)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class Conveyor : ResourceInformation
    {
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// 1 based sequence (1, 2, 3, ...)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public int Sequence { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Setpoint of conveyor speed of the processed unit.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double SpeedSetPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Measured conveyor speed of the processed unit in [cm/min].
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double SpeedReadingPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Setpoint of the width of the processed unit in [mm]
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double WidthSetPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Measured width of the transport in [mm]
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double WidthReadingPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Setpoint of center support position in [mm] 
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CenterSupportPositionSetPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Measured position of center support in [mm] 
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CenterSupportPositionReadingPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Setpoint of center support height in [mm] 
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CenterSupportHeightSetPoint { get; set; }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Measured height of center support in [mm] 
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CenterSupportHeightReadingPoint { get; set; }
    }
}
