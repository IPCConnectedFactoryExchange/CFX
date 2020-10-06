using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes the resources / sub-resources of a particular Endpoint that is participating in a CFX network, 
    /// and more specifically, is an SMT placement machine.  This is a dynamic structure.
    /// </summary>
    public class SMTPlacementResource : Resource
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SMTPlacementResource()
        {
           
        }

        /// <summary>
        /// Information about the camera of this SMT placement machine.
        /// </summary>
        public List<Camera> Cameras
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the conveyors of this SMT placement machine.
        /// </summary>
        public List<Conveyor> Conveyors
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the electric cards of this SMT placement machine.
        /// </summary>
        public List<ElectricCard> ElectricCards
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the gantries of this SMT placement machine.
        /// </summary>
        public List<Gantry> Gantries
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the nozzle changers of this SMT placement machine.
        /// </summary>
        public List<NozzleChanger> NozzleChangers
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the heads of this SMT placement machine.
        /// </summary>
        public List<HeadResource> PlacementHeads
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the tape cutter of this SMT placement machine.
        /// </summary>
        public List<TapeCutter> TapeCutters
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the vacuum pumps of this SMT placement machine.
        /// </summary>
        public List<VacuumPump> VacuumPumps
        {
            get;
            set;
        }
    }
}
