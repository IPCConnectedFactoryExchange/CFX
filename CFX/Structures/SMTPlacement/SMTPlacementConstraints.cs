using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes the placement constraints / capabilities of an SMT Placement Machine
    /// </summary>
    public class SMTPlacementConstraints
    {
        /// <summary>
        /// The minimum body size in the X dimension that a component
        /// must be in order to be placed.
        /// </summary>
        public double MinumumComponentBodySizeX
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum body size in the X dimension that a component
        /// may be in order to be placed.
        /// </summary>
        public double MaximumComponentBodySizeX
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum body size in the Y dimension that a component
        /// must be in order to be placed.
        /// </summary>
        public double MinumumComponentBodySizeY
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum body size in the Y dimension that a component
        /// may be in order to be placed.
        /// </summary>
        public double MaximumComponentBodySizeY
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum height that a component
        /// must be in order to be placed.
        /// </summary>
        public double MinumumComponentHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum height that a component
        /// may be in order to be placed.
        /// </summary>
        public double MaximumComponentHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum lead width that a component
        /// must have in order to be placed.
        /// </summary>
        public double MinimumLeadWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum ball pitch that a BGA type component
        /// must have in order to be placed.
        /// </summary>
        public double MinimumBGAPitch
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum lead pitch that an SOIC type component
        /// must have in order to be placed.
        /// </summary>
        public double MinimumSOICPitch
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of pressure that will be exerted on components during placement, 
        /// expressed in kPa
        /// </summary>
        public double MinimumMountingPressure
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of pressure that will be exerted on components during placement, 
        /// expressed in kPa
        /// </summary>
        public double MaximumMountingPressure
        {
            get;
            set;
        }
    }
}
