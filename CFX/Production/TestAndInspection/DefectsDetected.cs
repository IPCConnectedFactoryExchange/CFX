using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   List of only the defect components.
  ///   Always refers to a previously sent recipe (i.e. sent in a RecipeChanged message).
  /// </summary>
  public class DefectsDetected : CFXMessage
  {
    public Guid HermesID;
    public String Barcode;

    /// <summary> The inspection time includes feed in, image capture and analysis. (Currently not feed out.) </summary>
    public DateTime InspectionStart;
    /// <summary> Start of image capture and analysis (without feed in and out). </summary>
    public DateTime AnalysisStart;
    public DateTime AnalysisEnd;
    public DateTime InspectionEnd;

    /// <summary> In debug mode an operator is configuring the station and/or the inspection program. </summary>
    public bool? DebugMode;
    /// <summary> The inspection may have been aborted, either manually (by an operator) or due to machine errors. </summary>
    public bool? InspectionAborted;

    /// <summary>
    ///   UniqueID identifying the recipe this ("differential") list is based on.
    ///   Actually the UniqueID of the enevlope containing the RecipeChanged message.
    /// </summary>
    public Guid RecipeID;

    //TODO Naming: "panel" or "board" as name for the toplevel object (that itself conatains several sub-elements)?
    /// <summary>
    ///   The topmost "physical inspection object" (containing boards and components), but only
    ///   with the defect components.
    /// </summary>
    public CFXSPTI.Panel Panel;
  }

}
