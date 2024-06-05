namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Additional data for an item removal (local recipe change)
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class ItemRemovalLocalRecipeChange : LocalRecipeChange
    {
        /// <summary>
        /// Identifies the specific item that has been removed or restored.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the number of components (per unit) with this part number, that has been removed
        /// </summary>
        public double NumberOfComponentsPerUnit
        {
            get;
            set;
        }
    }
}
