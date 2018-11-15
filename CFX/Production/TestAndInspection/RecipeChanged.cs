using System;
using CFXSPTI = CFX.Structures.Production.TestAndInspection;


namespace CFX.Production.TestAndInspection
{

  /// <summary>
  ///   A recipe describes, starting with the panel as root object, all components to inspect.
  ///   It does not (yet) contain any inspection results.
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
