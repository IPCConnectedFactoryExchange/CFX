using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.ResourcePerformance;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the service and maintenance 
    /// of the resources / sub-resources in an Endpoint.
    /// It may be used to model as base class for other specific maintenance parts or services
    /// </summary>
    public class ServiceAndMaintenanceData
    {
        /// <summary>
        /// Unique identifier of the resource this data is about
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the resource this data is about
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The list of calibration details.
        /// </summary>
        public List<Calibration> CalibrationDetails
        {
            get;
            set;
        }

        /// <summary>
        /// The list of error details.
        /// </summary>
        public List<ErrorInformation> ErrorDetails
        {
            get;
            set;
        }

        /// <summary>
        /// The list of last executed maintenance and counters details.
        /// </summary>
        public List<MaintenanceInformation> MaintenanceDetails
        {
            get;
            set;
        }

        /// <summary>
        /// The list of sensor details.
        /// </summary>
        public List<SensorInformation> SensorDetails
        {
            get;
            set;
        }

        /// <summary>
        /// The list of verification details.
        /// </summary>
        public List<VerificationInformation> VerificationDetails
        {
            get;
            set;
        }
    }
}
