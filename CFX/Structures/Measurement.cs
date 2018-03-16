using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Measurement
    {
        public Measurement()
        {

        }

        /// <summary>
        /// A unique identifier that for this particular measurement instance
        /// (new and unique each time a new measurement is made or repeated).
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// A name that uniquely describes the test or measurement that was performed.
        /// </summary>
        public string MeasurementName
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time when this Measurement was recorded.
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
        public int Sequence
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating whether or not this reading is considered acceptable.
        /// </summary>
        public TestResult Result
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
        public byte[] BinaryValue
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

        public string MaximumAcceptableValue
        {
            get;
            set;
        }
    }
}
