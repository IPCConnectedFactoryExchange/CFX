

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Structure representing slide position and coating thickness measured in mils.
    /// </summary>
    public class CoatingThicknessMeasurement : Measurement
    {

        /// <summary>
        /// Position of measured slide.
        /// </summary>
        public byte Position
        {
            get;
            set;
        }
        /// <summary>
        /// Average coating thickness.
        /// </summary>
        public string Thickness
        {
            get;
            set;
        }
    }
}
