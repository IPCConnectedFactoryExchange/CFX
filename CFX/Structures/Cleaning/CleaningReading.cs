using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Cleaning readings / measurements that have been taken during the cleaning process
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class CleaningReading
    {
        /// <summary>
        /// The type of reading 
        /// </summary>
        public CleaningReadingType ReadingType
        {
            get;
            set;
        }
        /// <summary>
        /// The value of the reading (expressed in the appropriate units for the ReadingType)
        /// </summary>
        public double ? ReadingValue
        {
            get;
            set;
        }
    }
}
