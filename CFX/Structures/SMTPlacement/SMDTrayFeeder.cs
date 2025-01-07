namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes an SMT Tray carrier
    /// </summary>
    public class SMDTrayFeeder : MaterialCarrier
    {
        /// <summary>
        /// The x dimension of each cell in the tray carrier
        /// </summary>
        public double CellDimensionX
        {
            get;
            set;
        }

        /// <summary>
        /// The y dimension of each cell in the tray carrier
        /// </summary>
        public double CellDimensionY
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the x axis in this tray carrier
        /// </summary>
        public int CellCountX
        {
            get;
            set;
        }

        /// <summary>
        /// The number of cells in the y axis in this tray carrier
        /// </summary>
        public int CellCountY
        {
            get;
            set;
        }

        /// <summary>
        /// The x offset between adjacent cells in the tray carrier
        /// </summary>
        public double CellPitchX
        {
            get;
            set;
        }

        /// <summary>
        /// The y offset between adjacent cells in the tray carrier
        /// </summary>
        public double CellPitchY 
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Position in X of the material within the tray
        /// </summary>
        /// <summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CellNumberX
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Position in Y of the material within the tray
        /// </summary>
        /// <summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public double CellNumberY
        {
            get;
            set;
        }
    }
}
