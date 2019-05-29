using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   Describes, starting with the panel as root object, all components to inspect.
  ///   It contains the full hierarchy of inspection objects, with names, geometry and feature names. 
  ///   It does not contain any inspection results. Those are transmitted via the PanelInspected message.
  ///   
  ///   Similar to a "recipe" as in SECS/GEM, "inspection plan" or "program" (in the domain / field of
  ///   AOI/AXI) or "data model" (in Viscom vVision), but without the details on how to inspect.
  /// </summary>
  public class RecipeBaseInfo : CFXMessage
  {
    /// <summary>
    /// The constructor for the RecipeBaseInfo  class
    /// </summary>
    public RecipeBaseInfo () { }

    /// <summary>
    ///   The TransactionId as defined in the RecipeActivated message, where you can find name and
    ///   revision of this recipe.
    /// </summary>
    public Guid RecipeActivatedTransactionId { get; set; }

    /// <summary>
    ///   An unique identifier, so other messages can refer to this message.
    ///   Is referenced in the PanelInspected message.
    /// </summary>
    public Guid ID { get; set; }

    /// <summary>
    /// The panel description for the the recipe 
    /// </summary>
    public CFXSPTI.Panel Panel { get; set; }
  }

}
