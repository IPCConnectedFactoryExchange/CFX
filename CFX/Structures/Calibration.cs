using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A dynamic structure describing a calibration event.
    /// </summary>
    public class Calibration
    {
        /// <summary>
        /// A vendor-specific string based code identifying the specific calibration performed
        /// </summary>
        public string CalibrationCode
        {
            get;
            set;
        }
        
        /// <summary>
        /// An enumeration indicated the type of calibration that was performed
        /// </summary>
        public CalibrationType CalibrationType
        {
            get;
            set;
        }

        /// <summary>
        /// Free form comments related to this particular calibration
        /// </summary>
        public string Comments
        {
            get;
            set;
        }
    }
}
