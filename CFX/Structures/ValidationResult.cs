using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    public class ValidationResult
    {
        public ValidationResult()
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

        public ValidationStatus Result
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
