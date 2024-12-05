using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// Describes a shelf location
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    public class ShelfLocation : LocationDetail
    {
        /// <summary>
        /// The shelf side location
        /// </summary>
        public ShelfSideLocation SideLocation
        {
            get;
            set;
        }

        /// <summary>
        /// The number of rows of the shelf
        /// </summary>
        public double RowCount
        {
            get;
            set;
        }

        /// <summary>
        /// The number of columns of the shelf
        /// </summary>
        public double ColumnCount
        {
            get;
            set;
        }

        /// <summary>
        /// The specific row of the shelf of the location
        /// </summary>
        public double Row
        {
            get;
            set;
        }

        /// <summary>
        /// The specific column of the shelf of the location
        /// </summary>
        public double Column
        {
            get;
            set;
        }
    }
}
