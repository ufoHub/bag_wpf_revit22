// Ignore Spelling: Revit Rproj

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ARprojBase
{
  public static class RevitAPI
  {
    public static UIApplication UiApplication { get; set; }
    public static UIDocument UIDoc { get => UiApplication.ActiveUIDocument; }
    public static Document Doc { get => UIDoc.Document; }

    public static void Initialize(ExternalCommandData commandData)
    {
      UiApplication = commandData.Application;
    }
  }
}
