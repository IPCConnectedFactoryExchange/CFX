using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.UnitValidation
{
    public class ValidateUnitsResponse : CFXMessage
    {
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
