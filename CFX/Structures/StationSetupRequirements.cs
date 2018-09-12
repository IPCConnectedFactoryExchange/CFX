using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the material setup requirements for a particular process endpoint to perform a 
    /// particular operation on one or more partiuclar products.  Also includes information on
    /// where specifically the materials should be loaded (when applicable), AML (where applicable),
    /// and alternate part information (where applicable).
    /// </summary>
    public class StationSetupRequirements
    {
        public StationSetupRequirements()
        {
            MaterialSetupRequirements = new List<MaterialSetupRequirement>();
        }

        /// <summary>
        /// The production lane to which this setup applies (when applicable)
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The stage to which this setup applies (when applicable)
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// An optional name for this particular setup
        /// </summary>
        public string SetupName
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the materials that need to be installed / loaded at the process endpoint
        /// </summary>
        public List<MaterialSetupRequirement> MaterialSetupRequirements
        {
            get;
            private set;
        }

    }
}
