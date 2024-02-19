namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Order information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
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
