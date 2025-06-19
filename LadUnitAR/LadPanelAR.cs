using Autodesk.Revit.UI;
using System.Reflection;
using System.IO;
using ARprojBase;


namespace ARprojUnitAR
{
  internal class LadPanelAR : IExternalApplication
  {
    public static string assemblyPath = "";
    public static string assemblyDir = "";
    public Result OnStartup(UIControlledApplication application)
    {
      assemblyPath = Assembly.GetExecutingAssembly().Location;
      //assemblyDir = Path.GetDirectoryName(assemblyPath);
      assemblyDir = new FileInfo(assemblyPath).DirectoryName;

      string tabName = "LAD";
      try
      {
        application.CreateRibbonTab(tabName);
      }
      catch
      {
      }

      var btn1 = new PushButtonData("CalculateRoomArea", "Расчет\nПлощади.", assemblyPath, "ARprojUnitAR.RoomAreaCmd")
      {
        ToolTip = "Добавление дополнительного значения площади ниш окон и дверей, выберите все необходимые помещения",
        LargeImage = Properties.Resources.Area_bw.ToImageSource(),
        Image = Properties.Resources.Area_bw_16.ToImageSource()
      };

      var btn2 = new PushButtonData("FixRoomAre", "Блокир.\nПомещ.", assemblyPath, "ARprojUnitAR.FixRoomAreaCmd")
      {
        ToolTip = "Блокирование расчетной площади помещений от изменений аддоном.",
        LargeImage = Properties.Resources.Lock_bw.ToImageSource(),
        Image = Properties.Resources.Lock_bw_16.ToImageSource()
      };

      var btn3 = new PushButtonData("Apartments", "Квартиро\nграфия", assemblyPath, "ARprojUnitAR.FlatsAreaCmd")
      {
        ToolTip = "Расчет площади квартир, на основе площадей помещений Revit или специально вычисленной площади",
        LongDescription = "При подсчете площади через вычисленный параметр может быть учтена площадь проемов ниш дверей и окон." +
          "\n Внимание файле должны быть установлены необходимые общие параметры ЛАД и ADSK",
        LargeImage = Properties.Resources.Kvart_Bw.ToImageSource(),
        Image = Properties.Resources.Kvart_Bw_16.ToImageSource()
      };

      var btn4 = new PushButtonData("CalculateFinish", "Площадь\nотделки", assemblyPath, "ARprojUnitAR.FinishRoomAreaCmd")
      {
        ToolTip = "Расчет площади отделки стен помещения.",
        LargeImage = Properties.Resources.Finish_bw.ToImageSource(),
        Image = Properties.Resources.Finish_bw_16.ToImageSource()
      };

      var btn5 = new PushButtonData("FloorLinker", "Связать\nполы", assemblyPath, "ARprojUnitAR.FloorLinkerCmd")
      {
        ToolTip = "Связывает пол помещения построенный перекрытием с помещением.",
        LargeImage = Properties.Resources.FloorLinker.ToImageSource(),
        Image = Properties.Resources.FloorLinker_16.ToImageSource()
      };

      var btn6 = new PushButtonData("FlagManager2", "Флаг\nмен.", assemblyPath, "FlagManager.FlagManagerCmd")
      {
        ToolTip = "Менеджер управления флажками редактирование загрузка и сохранение в xlsx.",
        LargeImage = Properties.Resources.FlagManager.ToImageSource(),
        Image = Properties.Resources.FlagManger_16.ToImageSource()
      };
      
      var btn7 = new PushButtonData("FlagLink", "Флаг\nАвто", assemblyPath, "FlagLink.FlagLinkCmd")
      {
        ToolTip = "Создание флажка BIM с автозаполнением строк по материалам конструкций.",
        LargeImage = Properties.Resources.FlagLink.ToImageSource(),
        Image = Properties.Resources.FlagLink_16.ToImageSource()
      };

      var btn8 = new PushButtonData("FlagUpdater", "ПРОВЕРЬ БАГ.", assemblyPath, "FlagUpdater.FlagUpdaterCmd")
      {
        ToolTip = "Обновление флажков BIM",
        LargeImage = Properties.Resources.FlagUpdater.ToImageSource(),
        Image = Properties.Resources.FlagUpdater_16.ToImageSource()
      };

      RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Архитектура");

      var sbdApartments = new SplitButtonData("GroupApartments", "Квартирогрфия");
      var groupApartments = ribbonPanel.AddItem(sbdApartments) as SplitButton;


      var sbdFlag = new SplitButtonData("GroupFlag", "Флаг");
      var groupFlag = ribbonPanel.AddItem(sbdFlag) as SplitButton;

      groupApartments.AddPushButton(btn1);
      groupApartments.AddPushButton(btn2);
      groupApartments.AddPushButton(btn3);

      ribbonPanel.AddItem(btn4);
      ribbonPanel.AddItem(btn5);

      groupFlag.AddPushButton(btn6);
      groupFlag.AddPushButton(btn7);
      groupFlag.AddPushButton(btn8);

      ribbonPanel.AddSeparator();

      ribbonPanel.AddItem(btn8);

      return Result.Succeeded;
    }
    public Result OnShutdown(UIControlledApplication application)
    {
      return Result.Succeeded;
    }


  }
}