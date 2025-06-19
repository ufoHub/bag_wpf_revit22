// Вывод всплывающих предупреждений в облаке help


// Ignore Spelling: Rproj

using Autodesk.Internal.InfoCenter;
using Autodesk.Windows;

namespace ARprojBase
{
  public static class BalloonTip
  {
    public static void Show(string title, string message)
    {
      ComponentManager.InfoCenterPaletteManager.ShowBalloon(new ResultItem()
      {
        Category = title,
        Title = message,
        Type = 0,
        IsFavorite = true,
        IsNew = true
      });
    }
  }
}
