using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{

    /// <summary>
    /// A structure that describes an order to produce a specifified quantity of units of a particular part number /
    /// part revision within the factory environment.
    /// </summary>
    public class WorkOrder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkOrder()
        {
            Identifier = new WorkOrderIdentifier();
        }

        /// <summary>
        /// The identifer of the Work Order or Work Order sub-batch
        /// </summary>
        public WorkOrderIdentifier Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// A human friendly description for this Work Order.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// The current status of the Work Order.
        /// </summary>
        public WorkOrderStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the router or process that will be followed to produce the units for this Work Order.
        /// </summary>
        public string Router
        {
            get;
            set;
        }

        /// <summary>
        /// The revision of the router or process that will be followed to produce units for this Work Order.
        /// </summary>
        public string RouterRevision
        {
            get;
            set;
        }

        /// <summary>
        /// Ane lot number that is to be associated with units produced under this Work Order.
        /// </summary>
        public string LotNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An optional customer name, if this Work Order is associated with particular customer.
        /// </summary>
        public string Customer
        {
            get;
            set;
        }

        /// <summary>
        /// An optional department name, if this Work Order is to be executed by a particular department.
        /// </summary>
        public string Department
        {
            get;
            set;
        }

        /// <summary>
        /// The date on which the Work Order was created.
        /// </summary>
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time on which this Work Order should begin execution.
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time by which this Work Order should be completed.
        /// </summary>
        public DateTime DateRequired
        {
            get;
            set;
        }

        /// <summary>
        /// The part number (internal) of the assembly to be produced by this Work Order.
        /// </summary>
        public string PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The revision of the assembly to be produced by this Work Order.
        /// </summary>
        public string PartRevision
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of units to be produced by this Work Order.
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// If the Work Order is intended to produce something other than "units", the unit of measure of the 
        /// quantity associated with this Word Order.  For example, a Work Order might be placed to produce 200m
        /// of red wire.  In this case, the Quantity property would be "200" and the UnitOfMeasure
        /// would be "meter".  If UnitOfMeasure is left empty (blank), it is assumed that the quantity specifies
        /// "pieces" and/or "units" (200 units of assembly 1234-5678, for example).
        /// </summary>
        public string UnitOfMeasure
        {
            get;
            set;
        }

        /// <summary>
        /// A list of other Work Orders (or Work Order sub-batches) upon which this Work Order (or Work Order sub-batch) is dependent.
        /// Dependent Work Orders feed the supply of materials into upper level Work Orders.
        /// </summary>
        public List<WorkOrderIdentifier> DependsOn
        {
            get;
            set;
        }
    }
}
