using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

    /// <summary>
    /// List of only the defect components.
    /// Always refers to a previously sent RecipeBaseInfo message.
    /// </summary>
    public class PanelInspected : CFXMessage
    {
        /// <summary>
        /// The TransactionID as defined in the WorkStarted message, where you can find Lane and Units.
        /// </summary>
        public Guid WorkTransactionID { get; set; }

        /// <summary>
        /// A unique identifier of the current inspection. It is created during inspection and later used for
        /// reference during verification or repair.
        /// So even if the physically same board (i.e. same barcode) is inspected twice, both inspections can
        /// be distinguished using this ID.
        /// May be realized as barcode & timestamp or as GUID.
        /// </summary>
        public String InspectionID { get; set; }

        /// <summary>
        /// Stage where this inspection results were produced. Maybe null if not assignable to a specific stage.
        /// </summary>
        public CFX.Structures.Stage Stage { get; set; }

        /// <summary>
        /// In debug mode an operator is configuring the station and/or the inspection program.
        /// </summary>
        public bool? DebugMode { get; set; }

        /// <summary>
        /// The inspection may have been aborted, either manually (by an operator) or due to machine errors.
        /// </summary>
        public bool? InspectionAborted { get; set; }

        /// <summary>
        /// Unique ID identifying the RecipeBaseInfo message this ("differential") list is based on.
        /// </summary>
        public Guid RecipeBaseInfoID { get; set; }

        /// <summary>
        /// The topmost "physical inspection object" (containing boards and components), but typically 
        /// only with the defect components (may be configurable).
        /// </summary>
        public CFXSPTI.Panel Panel { get; set; }
    }

}
