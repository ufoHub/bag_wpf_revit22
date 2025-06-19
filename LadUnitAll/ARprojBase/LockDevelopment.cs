// Заглушка на методы в разработке или блокированные! 


// Ignore Spelling: Rproj

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ARprojBase
{
  [Transaction(TransactionMode.Manual)]
  public class LockDevelopment : IExternalCommand
  {
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      TaskDialog.Show("Разработка", "Данный инструмент находится в разработке!");

      return Result.Succeeded;
    }
  }
}
