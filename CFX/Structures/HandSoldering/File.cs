namespace CFX.Structures.HandSoldering
{
    public class File
    {
        /// <summary>
        /// Name of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The full name of the file.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The type of the file.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The file content.
        /// </summary>
        public byte[] FileData { get; set; }
    }
}
