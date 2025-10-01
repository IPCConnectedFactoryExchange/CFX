namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Additional data for the use of a component alternative (local recipe change)
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class ComponentAlternativeLocalRecipeChange : LocalRecipeChange
    {
        /// <summary>
        /// Identifies the specific component that must be replaced by the alternative part.
        /// If ComponentDesignator.PositionNumber is 0, the change applies to all the units of the panel.
        /// </summary>
        public ComponentDesignator Designator
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the alternative part number.
        /// </summary>
        public string AlternativePartNumber
        {
            get;
            set;
        }
    }
}
