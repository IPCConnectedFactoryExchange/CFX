using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    public class TestValidationResult
    {
        public TestValidationResult()
        {
        }

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public int PositionNumber
        {
            get;
            set;
        }

        public TestValidationStatus Result
        {
            get;
            set;
        }

        public int FailureCode
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
