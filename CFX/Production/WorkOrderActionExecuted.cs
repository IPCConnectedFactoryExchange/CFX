using System;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.2 **</para>
    /// Sent when a non-added value action (out of production) relative to a work order is started, aborted or completed by a process endpoint.
    /// <code language="none">
    /// {
    ///    "WorkOrderActionInstanceId": "dec7ca54-efc7-4519-a250-0bc7dbeae1d6",
    ///    "WorkOrderIdentifier": {
    ///     "WorkOrderId": "WO1122334455",
    ///     "Batch": null
    ///    },
    ///    "TimeStamp": "2018-08-01T13:46:15.5391201-04:00",
    ///    "Type": "PreProductionOperations",
    ///    "State": "Started",
    ///    "Comments": "Feeders loading",
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.2")]
    public class WorkOrderActionExecuted : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrderActionExecuted() : base()
        {
            WorkOrderActionInstanceId = Guid.NewGuid();
            WorkOrderIdentifier = new WorkOrderIdentifier();
            TimeStamp = DateTime.Now;
            Type = WorkOrderActionType.Uncategorized;
            State = WorkOrderActionState.Completed;
        }

        /// <summary>
        /// An id uniquely identfying a particular instance of work order action. If the same work order action occurs x times, each
        /// instance shall have a unique identifier.
        /// </summary>
        public Guid WorkOrderActionInstanceId
        {
            get;
            set;
        }

        /// <summary>
        /// The identifer of the Work Order or Work Order sub-batch
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the work order action transitioned to the state specified by the State property.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// The type of action of the work order action.
        /// </summary>
        public WorkOrderActionType Type
        {
            get;
            set;
        }

        /// <summary>
        /// The current state of the work order action (started, completed, etc.).
        /// </summary>
        public WorkOrderActionState State
        {
            get;
            set;
        }

        /// <summary>
        /// Optional free-form comments associated with the work order action.
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// For two-dimensional products, such as printed circuit assemblies,
        /// specifies the relevant surface that is concerned by the action. (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public Surface RelevantSurface
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// The name of the recipe, when a particular surface and a particular machine
        /// are involved in the action (may include full path, if applicable) (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// Recipe version number, when a recipe name is defined (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        public string RecipeRevision
        {
            get;
            set;
        }
    }
}
