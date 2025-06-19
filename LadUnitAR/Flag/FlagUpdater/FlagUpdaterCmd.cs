using ARprojBase;
using ARprojInterface;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;


namespace FlagUpdater
{
  [Transaction(TransactionMode.Manual)]
  public class FlagUpdaterCmd : IExternalCommand
  {
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      if (RevitAPI.UiApplication == null)
        RevitAPI.Initialize(commandData);

      IRevitExecute command = new FlagUpdater(); // Основной класс плагина
      return command.Execute();
    }
  }
}