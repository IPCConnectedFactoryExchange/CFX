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
      /// <summary>
      /// The TransactionID as defined in the WorkStarted message, where you can find Lane and Units.
      /// </summary>
      // ReSharper disable once InconsistentNaming
      public Guid WorkTransactionID { get; set; }

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
    ///   The topmost "physical inspection object" (containing boards and components), but only
    ///   with the defect components.
    /// </summary>
    public CFXSPTI.Panel Panel { get; set; }
    }

}
