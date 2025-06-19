using ARprojInterface;
using Autodesk.Revit.UI;

namespace FlagUpdater
{
  public class FlagUpdater : IRevitExecute
  {
    public Result Execute()
    {
      Update();
      return Result.Succeeded;
    }

    public int Update()
    {
      TaskDialog.Show("БАГ ?", "Это окно WinForms следущее окно Проверка WPF");
      var view = new FlagUpdaterView();
      view.ShowDialog();

      return 0;
    }




  }
}
