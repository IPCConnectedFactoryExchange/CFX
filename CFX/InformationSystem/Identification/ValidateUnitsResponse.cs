using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.InformationSystem.Identification
{
    public class ValidateUnitsResponse
    {
        public ValidateUnitsResponse()
        {
        }

        public ValidationResult PrimaryResult
        {
            get;
            set;
        }

        public List<ValidationResult> Results
        {
            get;
            set;
        }
    }
}
