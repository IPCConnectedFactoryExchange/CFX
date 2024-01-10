namespace CFX.Structures.HandSoldering
{
    public class Component
    {
        /// <summary>
        /// The component name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The component type.
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// The maximal allowed temperature.
        /// </summary>
        public int MaxTemperature { get; set; }

        /// <summary>
        /// The maximal allowed process time.
        /// </summary>
        public int MaxTime { get; set; }
    }
}
