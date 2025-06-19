using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace ModifyElements
{
  public class ElementSelectionFilter : ISelectionFilter
  {
    public bool AllowElement(Element elem)
    {
      return elem.Category != null;
    }
    public bool AllowReference(Reference reference, XYZ position) => false;
  }

}
