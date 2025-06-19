// Настройки 
// Сериализация

// Ignore Spelling: Rproj

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;


namespace ARprojBase
{
  [Serializable]
  public class Config
  {
    // =======================================================================================
    // ExtraParameter - класс с сохранением найденного Guid или работой через него.
    // =======================================================================================

    //==========ЛАД Расчет площади отделки помещений (FinishRoomAreaCmd)======================
    //----------Параметры семейства----------------------------------------------------------- 
    public ExtraParameter SideWidth = new ExtraParameter("Глубина откосов");
    public ExtraParameter OpeningsWidth = new ExtraParameter("Ширина");
    public ExtraParameter OpeningsHeight = new ExtraParameter("Высота");
    public ExtraParameter OpeningsArea = new ExtraParameter("ADSK_Площадь проемов");
    //----------Параметры помещений-----------------------------------------------------------
    public ExtraParameter SeparatorArea = new ExtraParameter("ЛАД_Площадь разделителей");
    public ExtraParameter WallDownArea = new ExtraParameter("ЛАД_Площадь стен или низа стен");
    public ExtraParameter WallUpArea = new ExtraParameter("ЛАД_Площадь верха стен");
    public ExtraParameter WallHight = new ExtraParameter("ЛАД_Высота низа стен");
    public ExtraParameter WindowsSideArea = new ExtraParameter("ЛАД_Площадь откосов окон");
    public ExtraParameter DoorSideArea = new ExtraParameter("ЛАД_Площадь откосов дверей");

    //==========ЛАД Расчет площади помещений (RoomAreaCmd======================================
    public ExtraParameter RoomType = new ExtraParameter("ADSK_Тип помещения");
    public ExtraParameter FixArea = new ExtraParameter(new Guid("eb02c8f0-b2ce-4909-a93a-54e007eb700e"));
    public ExtraParameter CalculationArea = new ExtraParameter(new Guid("2329fb4e-13e4-49c2-b6a8-91dd55c73d4a"));

    public int RoundCount { get; set; } = 2;
    public double CoefficientLoggia { get; set; } = 0.50;
    public double CoefficientBalcony { get; set; } = 0.30;


    public string RoomFileError { get; set; } = "C:\\Users\\Public\\Documents\\RoomArea.txt";

    //==========ЛАД Квартирография помещений (FlatCmd)=========================================
    public ExtraParameter RoomNumber = new ExtraParameter("ADSK_Номер помещения квартиры");
    //public ExtraParameter RoomType = new ExtraParameter("ADSK_Тип помещения");
    public ExtraParameter RoomIndex = new ExtraParameter("ADSK_Индекс помещения");
    public ExtraParameter RoomRoundArea = new ExtraParameter("ЛАД_Площадь помещения");
    public ExtraParameter RoomCoefficient = new ExtraParameter("ADSK_Коэффициент площади");
    public ExtraParameter RoomCoefficientArea = new ExtraParameter("ADSK_Площадь с коэффициентом");
    public ExtraParameter FlatNumber = new ExtraParameter("ADSK_Номер квартиры");
    public ExtraParameter FlatCountRoom = new ExtraParameter("ADSK_Количество комнат");
    public ExtraParameter FlatType = new ExtraParameter("ADSK_Тип квартиры");
    public ExtraParameter FlatLivingArea = new ExtraParameter("ADSK_Площадь квартиры жилая");
    public ExtraParameter FlatBTIArea = new ExtraParameter("ADSK_Площадь квартиры");
    public ExtraParameter FlatFetchArea = new ExtraParameter(new Guid("af973552-3d15-48e3-aad8-121fe0dda34e"));
    //public ExtraParameter FlatFetchArea = new ExtraParameter("ADSK_Площадь квартиры общая");^^^^приведенная
    // "ЛАД_Площадь квартиры приведенная"
    public ExtraParameter FlatTotalArea = new ExtraParameter("ЛАД_Площадь квартиры общая");

    //==========ЛАД установка уровня (LevelSetterCmd)===========================================
    public string LevelFileError { get; } = "C:\\Users\\Public\\Documents\\Levels.txt";
    public ExtraParameter LevelString = new ExtraParameter(new Guid("9eabf56c-a6cd-4b5c-a9d0-e9223e19ea3f")); // ADSK_Этаж.
    public ExtraParameter LevelValue = new ExtraParameter("Уровень элемента"); // Денежная единица.

    //==========ЛАД Номера и имена для спецификации (LevelSetterCmd)===========================================
    public ExtraParameter NameExternNumber = new ExtraParameter("ЛАД_Имя с номером");
    public ExtraParameter RoomListNumbers = new ExtraParameter("Помещение Список номеров");
    public ExtraParameter RoomListNames = new ExtraParameter("Помещение Список имен");
    public ExtraParameter Section = new ExtraParameter("ADSK_Номер секции");
    //==========ЛАД привязка пола к перекрытию (FloorLinksCmd)===========================================
    public string FloorNameContents { get; } = "ЛАД_Пол_";
    public ExtraParameter FloorName = new ExtraParameter("Помещение Имя");
    public ExtraParameter FloorRoomID = new ExtraParameter("Относится к помещению");
  }
}
