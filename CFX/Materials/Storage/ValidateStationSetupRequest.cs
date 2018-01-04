using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    public class ValidateStationSetupRequest : CFXMessage
    {
        public StationSetupRequirements SetupRequirements
        {
            get;
            set;
        }
    }
}
