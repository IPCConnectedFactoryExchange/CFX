

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Structure base class representing slide position.
    /// Average coating thickness measured in micrometers.
    /// </summary>
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
