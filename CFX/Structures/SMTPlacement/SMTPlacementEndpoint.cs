﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes the details of a particular Endpoint that is participating in a CFX network, 
    /// and more specifically, is an SMT placement machine.  This is a dynamic structure.
    /// </summary>
    public class SMTPlacementEndpoint : Endpoint
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SMTPlacementEndpoint()
        {
            Lanes = new List<SMTLaneInformation>();
        }

        /// <summary>
        /// The nominal number of components that this endpoint can place per hour.
        /// </summary>
        public double NominalPlacementCPH
        {
            get;
            set;
        }

        /// <summary>
        /// The average (nominal) number of production units per hour this endpoin
        /// is capable of producing.
        /// </summary>
        public double NominalUnitsPerHour
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the production lanes of this SMT placement machine.
        /// </summary>
        public List<SMTLaneInformation> Lanes
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the heads of this SMT placement machine.
        /// </summary>
        public List<SMTHeadInformation> Heads
        {
            get;
            set;
        }

        /// <summary>
        /// The placement constraints / capabilities of this endpoint.
        /// </summary>
        public SMTPlacementConstraints PlacementConstraints
        {
            get;
            set;
        }
    }
}
