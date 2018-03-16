using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Image
    {
        public Image ()
        {
            MimeType = "image/jpg";
            ImageData = new byte[0];
        }

        /// <summary>
        /// The MIME type of the binary image data contained by the ImageData property.
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// A binary representation of the image.
        /// </summary>
        public byte[] ImageData
        {
            get;
            set;
        }
    }
}
