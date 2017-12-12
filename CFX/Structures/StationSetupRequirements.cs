using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class StationSetupRequirements
    {
        public StationSetupRequirements()
        {
            MaterialSetupRequirements = new List<MaterialSetupRequirement>();
        }

        /// <summary>
        /// An optional property designating the applicable Lane.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the applicable Stage.
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
