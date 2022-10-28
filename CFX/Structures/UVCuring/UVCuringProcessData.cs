using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.UVCuring
{
    /// <summary>
    /// UV Curing Process Data
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    public class UVCuringProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UVCuringProcessData()
        {
            this.UVLamps = new List<UVCuringLampData>();
        }

        /// <summary>
        /// Time of the part in process in seconds.
        /// </summary>
        public NumericMeasurement ProcessTime
        {
            get;
            set;
        }

        /// <summary>
        /// Speed of the conveyor in mm/s.
        /// </summary>
        public NumericMeasurement ConveyorSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Width of the conveyor in mm.
        /// </summary>
        public NumericMeasurement ConveyorWidth
        {
            get;
            set;
        }

        /// <summary>
        /// UV itensity in mW/cm^2
        /// </summary>
        public NumericMeasurement Intensity
        {
            get;
            set;
        }

        /// <summary>
        /// List of all lamps in the UV machine.
        /// </summary>
        public List<UVCuringLampData> UVLamps
        {
            get;
            set;
        }


        /// <summary>
        /// List of all glass plates in the UV machine.
        /// </summary>
        public List<UVCuringGlassPlate> GlassPlates
        {
            get;
            set;
        }
    }
}
