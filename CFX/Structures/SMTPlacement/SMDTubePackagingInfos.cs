namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Describes the packaging infos of an SMD tape
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class SMDTubePackagingInfos : PackagingInfos
    {
        /// <summary>
        /// The width of the tube (in millimeters)
        /// </summary>
        public double TubeWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The pitch (spacing between parts) of the tube (in millimeters)
        /// </summary>
        public double TubePitch
        {
            get;
            set;
        }

        /// <summary>
        /// The length of the tube (in millimeters)
        /// </summary>
        public double TubeLength
        {
            get;
            set;
        }

        /// <summary>
        /// The thickness of the tube (in millimeters)
        /// </summary>
        public double TubeThickness
        {
            get;
            set;
        }
    }
}