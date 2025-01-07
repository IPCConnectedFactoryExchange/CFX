namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Describes a multi-tray feeder, which is typically a feeder that can accomodate multiple trays/matrice
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SMDMultiTrayFeeder : MaterialCarrier
    {
        /// <summary>
        /// An endpoint specific identifier that designs a particular location within the tray feeder (optional)
        /// </summary>
        public string InternalIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// X coordinate of the location origin within the tray feeder, expressed in millimeters (mm)
        /// </summary>
        public double X
        {
            get;
            set;
        }

        /// <summary>
        /// Y coordinate of the location origin within the tray feeder, expressed in millimeters (mm)
        /// </summary>
        public double Y
        {
            get;
            set;
        }

        /// <summary>
        /// Orientation of the location within the tray feeder, expressed in degrees
        /// </summary>
        public double Rotation
        {
            get;
            set;
        }
    }
}
