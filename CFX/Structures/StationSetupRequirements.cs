using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class StationSetupRequirements
    {
        public StationSetupRequirements()
        {
            MaterialSetupRequirements = new List<MaterialSetupRequirement>();
        }

        /// <summary>
        /// The production lane to which this setup applies (when applicable)
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The stage to which this setup applies (when applicable)
        /// </summary>
        public string Stage
        {
            get;
            set;
        }

        /// <summary>
        /// An optional name for this particular setup.
        /// </summary>
        public string SetupName
        {
            get;
            set;
        }

        public List<MaterialSetupRequirement> MaterialSetupRequirements
        {
            get;
            private set;
        }

    }
}
