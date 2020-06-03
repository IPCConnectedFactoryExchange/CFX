

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// NOTE:  ADDED in CFX 1.2
    /// Structure base class representing slide position.
    /// Average coating thickness measured in micrometers.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class CoatingThicknessMeasurement : Measurement
    {

        /// <summary>
        /// Position of measured slide.
        /// </summary>
        public ushort Position
        {
            get;
            set;
        }
        /// <summary>
        /// Average coating thickness in micrometers.
        /// </summary>
        public double Thickness
        {
            get;
            set;
        }
    }
}
