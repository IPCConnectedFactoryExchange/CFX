namespace CFX.Structures.HandSoldering
{
    public class Order
    {
        /// <summary>
        /// The actual order size.
        /// </summary>
        public int OrderSize { get; set; }

        /// <summary>
        /// The size of the order.
        /// </summary>
        public int TargetOrderSize { get; set; }

        /// <summary>
        /// The number of the order.
        /// </summary>
        public int OrderNumber { get; set; }
    }
}
