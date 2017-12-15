using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;

namespace CFX.InformationSystem.UnitValidation
{
    public class ValidateUnitsRequest : CFXMessage
    {
        public ValidateUnitsRequest()
        {
            Validations = new List<ValidationType>();
            Units = new List<UnitPosition>();
        }

        public List<ValidationType> Validations
        {
            get;
            set;
        }

        public string PrimaryIdentifier
        {
            get;
            set;
        }

        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
