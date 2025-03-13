namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Additional data for a unit skip (local recipe change)
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class UnitSkipLocalRecipeChange : LocalRecipeChange
    {
        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6) that is removed or restored for production.
        /// </summary>
        public int PositionNumber
        {
            get;
            set;
        }
    }
}
