using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;

namespace CFX
{
    public class Reading
    {
        public Reading()
        {
            Components = new List<ComponentDesignator>();
        }

        /// <summary>
        /// A name that uniquely describes the test or measurement that was performed.
        /// </summary>
        public string ReadingIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time when this Reading was recorded.
        /// </summary>
        public DateTime TimeRecorded
        {
            get;
            set;
        }

        /// <summary>
        /// An optional positive integer describing the sequence in which the tests or measurements were performed
        /// that resulted in this Reading.
        /// /// </summary>
        public int ReadingSequence
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating whether or not this reading is considered acceptable.
        /// </summary>
        public StatusResult Result
        {
            get;
            set;
        }
        
        /// <summary>
        /// In the case that this Reading is associated to a particular production unit, and the Reading is not associated
        /// with a work transaction, this property contains the unique identifier of the production unit.
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }


        /// <summary>
        /// In the case that this Reading is associated with a particular production unit, and the Reading is associated
        /// with a work transaction, this property contains the position number of the unit as it relates to the transaction.  
        /// If a position number is not specified, it is assumed that the Reading applies to all units associated with the
        /// transaction.
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of components (instance of a part) on a production unit(s) to be associated with this reading.
        /// </summary>
        public List<ComponentDesignator> Components
        {
            get;
            set;
        }


        public DataType ValueDataType
        {
            get;
            set;
        }

        public string ValueUnits
        {
            get;
            set;
        }

        /// <summary>
        /// If the Reading is of type DataType.Binary, this property contains the MIME type
        /// of the binary data contained in the BinaryValue property.
        /// </summary>
        public string ValueMimeType
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// If the Reading is of type DataType.Binary, this property contains the binary
        /// representation of the value.
        /// </summary>
        public byte [] BinaryValue
        {
            get;
            set;
        }

        public string ExpectedValue
        {
            get;
            set;
        }

        public string ExpectedValueUnits
        {
            get;
            set;
        }

        public string MinimumAcceptableValue
        {
            get;
            set;
        }

        public string MaxumumAcceptableValue
        {
            get;
            set;
        }
    }
}
