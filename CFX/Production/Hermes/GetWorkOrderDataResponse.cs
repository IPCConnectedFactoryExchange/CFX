using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// Reponse to a request by a Hermes enabled endpoint to acquire information related to a particular work order.
    /// </summary>
    public class GetWorkOrderDataResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetWorkOrderDataResponse()
        {
            WorkOrderIdentifier = new WorkOrderIdentifier();
            Surface = Surface.Unspecified;
        }

        /// <summary>
        /// Result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The identifier of the work order whose data was retrieved.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes product type Id of the assembly that is associated with this work order.
        /// </summary>
        public string ProductTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// The length of the PCB in millimeters (mm)
        /// </summary>
        public double Length
        {
            get;
            set;
        }

        /// <summary>
        /// The width of the PCB in millimeters (mm)
        /// </summary>
        public double Width
        {
            get;
            set;
        }

        /// <summary>
        /// The thickness of the PCB in millimeters (mm)
        /// </summary>
        public double Thickness
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the top side of the PCB millimeters (mm)
        /// </summary>
        public double TopClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the bottom side of the PCB millimeters (mm)
        /// </summary>
        public double BottomClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The weight of the PCB in grams (g)
        /// </summary>
        public double Weight
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Identifies the surface of the product that is relevant to this Work Order (if any)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public Surface Surface
        {
            get;
            set;
        }
    }
}
