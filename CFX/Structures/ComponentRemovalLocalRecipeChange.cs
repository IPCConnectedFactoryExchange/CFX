namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Additional data for a component removal (local recipe change)
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class ComponentRemovalLocalRecipeChange : LocalRecipeChange
    {
        /// <summary>
        /// Identifies the specific component that has been removed or restored.
        /// If ComponentDesignator.PositionNumber is 0, the change applies to all the units of the panel.
        /// </summary>
        public ComponentDesignator Designator
        {
            get;
            set;
        }
    }
}
