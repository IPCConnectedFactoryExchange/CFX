namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Material information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
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
