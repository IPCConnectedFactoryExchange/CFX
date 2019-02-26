using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   A recipe describes, starting with the panel as root object, all components to inspect.
  ///   It does not contain any inspection results. Those are transmitted via the DefectsDetected message.
  ///   
  ///   The name is inspired from SECS/GEM "recipe". Synonyms are "inspection program" (in the domain / field of AOI/AXI)
  ///   or "data model" (in Viscom vVision).
  /// </summary>
  public class RecipeChanged : CFXMessage
  {
    public RecipeChanged () { }

    public CFXSPTI.Panel Panel;
  }

}
