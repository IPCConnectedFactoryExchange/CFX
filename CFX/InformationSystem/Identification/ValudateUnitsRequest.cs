using System;
using System.Collections.Generic;
using System.Text;
using CFX;

namespace CFX.InformationSystem.Identification
{
    public class ValudateUnitsRequest
    {
        public ValudateUnitsRequest()
        {
            Validations = new List<ValidationType>();
            Units = new List<UnitPosition>();
        }

        public List<ValidationType> Validations
        {
            get;
            private set;
        }

        public string PrimaryIdentifier
        {
            get;
            set;
        }

        public List<UnitPosition> Units
        {
            get;
            private set;
        }
    }
}
