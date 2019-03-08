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

    public Guid ID;
    public CFXSPTI.Panel Panel;
  }

}
