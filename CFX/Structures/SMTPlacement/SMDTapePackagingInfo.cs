namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Describes the packaging infos of an SMD tape
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class SMDTapePackagingInfo : PackagingInfo
    {
        /// <summary>
        /// The width of the tape (in millimeters)
        /// </summary>
        public double TapeWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The pitch (spacing between parts) of the tape (in millimeters)
        /// </summary>
        public double TapePitch
        {
            get;
            set;
        }

        /// <summary>
        /// The diameter of the tape (in millimeters)
        /// </summary>
        public double TapeDiameter
        {
            get;
            set;
        }

        /// <summary>
        /// The thickness of the tape (in millimeters)
        /// </summary>
        public double TapeThickness
        {
            get;
            set;
        }
    }
}