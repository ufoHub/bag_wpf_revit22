// Ignore Spelling: Rproj

using ARprojBase;
using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;


namespace ARprojUnitAll
{
  public class LadPanelAll : IExternalApplication
  {
    public static string assemblyPath = "";
    public static string assemblyFolder = "";

    public Result OnStartup(UIControlledApplication application)
    {
      assemblyPath = Assembly.GetExecutingAssembly().Location;
      assemblyFolder = Path.GetDirectoryName(assemblyPath);
      string tabName = "LAD";
      try
      {
        application.CreateRibbonTab(tabName);
      }
      catch
      {
      }

      var btnAbout = new PushButtonData("HelpAbout", "ЛАД\nПРОЕКТ", assemblyPath, "ARprojUnitHelp.HelpAboutCmd")
      {
        ToolTip = "Сведения об компонентах аддона ЛАД и номерах версии, разработал: Крикунов А.С. ",
        LargeImage = Properties.Resources.LAD_32.ToImageSource()
      };

      var btn1 = new PushButtonData("RenumberElement", "Номер\nэлем-та.", assemblyPath, "ARprojUnitAll.RenumberElementCmd")
      {
        ToolTip = "Задание нового номера для оси, помещения вида или листа",
        LargeImage = Properties.Resources.RenumberElement.ToImageSource(),
        Image = Properties.Resources.RenumberElement_16.ToImageSource()
      };

      var btn2 = new PushButtonData("RenumberSheet", "Номера\nлистов", assemblyPath, "ARprojUnitAll.RenumberSheetCmd")
      {
        ToolTip = "Перенумерация группы выбранных листов, с префиксом суффиксом и возможностью создавать одинаковые номера листов\n" +
          "Для начала выберите все листы которые хотите перенумеровать.",
        LargeImage = Properties.Resources.RenumberSheet.ToImageSource(),
        Image = Properties.Resources.RenumberSheet_16.ToImageSource()
      };

      PushButtonData btn3 = new PushButtonData("SummaParameter", "Сумма\nпараметра", assemblyPath, "ARprojSumm.SummaryParameterCmd")
      {
        ToolTip = "Сумма значений выбранного параметра у выбранных элементов",
        LargeImage = Properties.Resources.SummaryParameter.ToImageSource(),
        Image = Properties.Resources.SummaryParameter_16.ToImageSource()
      };


      PushButtonData btn4 = new PushButtonData("BaseLevel", "Уровень\nэтажа", assemblyPath, "ARprojLevelSetter.LevelSetterCmd")
      {
        ToolTip = "Запись значения уровня в параметры элемента \"Уровень элемента\" - число и \"ADSK_Этаж\" - текст",
        LargeImage = Properties.Resources.BaseLevel.ToImageSource(),
        Image = Properties.Resources.BaseLevel_16.ToImageSource()
      };

      PushButtonData btn5 = new PushButtonData("SectionBox3D", "Сечение\n3D", assemblyPath, "ARprojUnitAll.SectionBox3DCmd")
      {
        ToolTip = "Создание усеченного 3D вида, по двум точкам на плане этажа, с учетом поворота вида, высота сечения настраивается",
        LargeImage = Properties.Resources.SectionBox3D.ToImageSource(),
        Image = Properties.Resources.SectionBox3D_16.ToImageSource()
      };

      PushButtonData btn6 = new PushButtonData("MoveZElements", "Сдвиг\nвверх", assemblyPath, "ModifyElements.MoveZElementsCmd")
      {
        ToolTip = "Перемещение элемента вверх, элемент можно выбрать на любом виде пока работает с некоторыми элементами",
        LargeImage = Properties.Resources.MoveZElement.ToImageSource(),
        Image = Properties.Resources.MoveZElement_16.ToImageSource()
      };

      PushButtonData btn7 = new PushButtonData("SwapElements", "Разве-\nрнуть", assemblyPath, "ModifyElements.SwapElementsCmd")
      {
        ToolTip = "Разворот элемента на 180, каждый элемент развернется вокруг собственного центра",
        LargeImage = Properties.Resources.SwapElement.ToImageSource(),
        Image = Properties.Resources.SwapElement_16.ToImageSource()
      };


 
      RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Общие");

      ribbonPanel.AddItem(btnAbout);
      ribbonPanel.AddSeparator();
      ribbonPanel.AddItem(btn1);
      ribbonPanel.AddItem(btn2);
      ribbonPanel.AddSeparator();
      ribbonPanel.AddItem(btn3);
      ribbonPanel.AddSeparator();
      ribbonPanel.AddItem(btn4);
      ribbonPanel.AddSeparator();
      ribbonPanel.AddItem(btn5);
      ribbonPanel.AddSeparator();
      var sbdEdit = new SplitButtonData("GroupEditElement", "Редактирование элементов");
      var groupEditElement = ribbonPanel.AddItem(sbdEdit) as SplitButton;
      groupEditElement.AddPushButton(btn6);
      groupEditElement.AddPushButton(btn7);

      return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    { return Result.Succeeded; }

  }
}
