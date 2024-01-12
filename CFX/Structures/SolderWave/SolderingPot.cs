using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class SolderingPot
    {
        public double ZAxisSetpoint { get; set; }

        public double ZAxisReadingValue { get; set; }

        public SolderPotHeating Heating { get; set; }

        public List<SolderingWave> SolderingWaves { get; set; }
    }
}
