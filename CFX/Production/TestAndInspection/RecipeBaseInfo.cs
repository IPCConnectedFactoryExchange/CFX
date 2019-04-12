using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   Describes, starting with the panel as root object, all components to inspect.
  ///   It contains the full hierarchy of inspection objects, with names, geometry and feature names. 
  ///   It does not contain any inspection results. Those are transmitted via the DefectsDetected message.
  ///   
  ///   Similar to a "recipe" as in SECS/GEM, "inspection plan" or "program" (in the domain / field of
  ///   AOI/AXI) or "data model" (in Viscom vVision), but without the details on how to inspect.
  /// </summary>
  public class RecipeBaseInfo : CFXMessage
  {
    public RecipeBaseInfo () { }


    /// <summary>
    /// A new recipe is activated in this station and all events related to this recipe instance share the same 
    /// Id of the transaction. One example is the RecipeBaseInfo which provides more recipe content information. 
    /// </summary>
    public Guid TransactionId { get; set; }

        public Guid ID { get; set; }
     
     public CFXSPTI.Panel Panel { get; set; }
  }

}
