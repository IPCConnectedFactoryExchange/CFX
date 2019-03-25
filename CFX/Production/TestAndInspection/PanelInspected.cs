using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   List of only the defect components.
  ///   Always refers to a previously sent InspectionBaseInfo message.
  /// </summary>
  public class PanelInspected : CFXMessage
  {
    /// <summary> The TransactionID as defined in the WorkStarted message, where you can find Lane and Units. </summary>
    public Guid WorkTransactionID;
    //TODO If WorkStageStarted had a TransactionID itself (in addition to the WorkStarted.TransactionID), then
    //     we could reference that and omit the Stage property below.
    /// <summary>
    ///   The TransactionID as defined in the WorkStageStarted message, where you can find the Stage
    ///   where this inspection results were produced.
    ///   Maybe null if not assignable to a specific stage.
    /// </summary>
    //public Guid WorkStageTransactionID;
    /// <summary> Stage where this inspection results were produced. Maybe null if not assignable to a specific stage.</summary>
    public CFX.Structures.Stage Stage;
    //TODO Not necessary if all units are always processed together anyway.
    ///// <summary> As defined in the WorkStarted and UnitsArrived messages. </summary>
    //public String UnitIdentifier;
    //TODO Remove
    //public Guid HermesID;

    //TODO Remove
    //     Measurement of timings should be done via WorkStarted/Completed and/or WorkStageStarted/Completed.
    /// <summary> The inspection time includes feed in, image capture and analysis. (Currently not feed out.) </summary>
    //public DateTime InspectionStart;
    ///// <summary> Start of image capture and analysis (without feed in and out). </summary>
    //public DateTime AnalysisStart;
    //public DateTime AnalysisEnd;
    //public DateTime InspectionEnd;

    /// <summary> In debug mode an operator is configuring the station and/or the inspection program. </summary>
    public bool? DebugMode;
    /// <summary> The inspection may have been aborted, either manually (by an operator) or due to machine errors. </summary>
    public bool? InspectionAborted;

    /// <summary> Unique ID identifying the InspectionBaseInfo message this ("differential") list is based on. </summary>
    public Guid RecipeBaseInfoID;

    //TODO Naming: "panel" or "board" as name for the toplevel object (that itself conatains several sub-elements)?
    //TODO Should be configurable, if only defects or all inspection results are transmitted.
    //     On demand, even the positions (and rotation values) could be included, so no RecipeBaseInfo
    //     would be necessary.
    /// <summary>
    ///   The topmost "physical inspection object" (containing boards and components), but only
    ///   with the defect components.
    /// </summary>
    public CFXSPTI.Panel Panel;
  }

}
