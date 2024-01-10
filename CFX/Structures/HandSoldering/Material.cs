namespace CFX.Structures.HandSoldering
{
    public class Material
    {
        /// <summary>
        /// The material name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The material type.
        /// </summary>
        public MaterialType Type { get; set; }

        /// <summary>
        /// The custom material description.
        /// </summary>
        public string CustomMaterial { get; set; }
    }
}
