
namespace CFX.Structures
{
    /// <summary>
    /// Structure representing coating thickness and slide position.
    /// </summary>
    public class CoatingMeasurement
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
