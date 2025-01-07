namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Describes the packaging infos of an SMD tape
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SMDTrayPackagingInfo : PackagingInfo
    {
        /// <summary>
        /// The x dimension of each cell in the tray
        /// </summary>
        public double CellDimensionX
        {
            get;
            set;
        }

        /// <summary>
        /// The y dimension of each cell in the tray
        /// </summary>
        public double CellDimensionY
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the x axis in this tray
        /// </summary>
        public int CellCountX
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the y axis in this tray
        /// </summary>
        public int CellCountY
        {
            get;
            set;
        }

        /// <summary>
        /// The x offset between adjacent cells in the tray
        /// </summary>
        public double CellPitchX
        {
            get;
            set;
        }

        /// <summary>
        /// The y offset between adjacent cells in the tray
        /// </summary>
        public double CellPitchY
        {
            get;
            set;
        }
    }
}