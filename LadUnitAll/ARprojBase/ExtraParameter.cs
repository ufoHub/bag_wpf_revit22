// Тип для установки параметров и их кеширования.

// Ignore Spelling: Rproj

using Autodesk.Revit.DB;
using System;

namespace ARprojBase
{
  public class ExtraParameter
  {
    public string Name { get; set; } = null;
    public Guid Guid { get; set; } = Guid.Empty;

    public ExtraParameter()
    {
      ;
    }

    public ExtraParameter(string name)
    {
      Name = name;
    }

    public ExtraParameter(Guid guid)
    {
      Guid = guid;
    }


    public Parameter Activate(Element element)
    {
      try
      {
        Parameter parameter = null;
        if (Guid == Guid.Empty)
        {
          parameter = element.LookupParameter(Name) ?? element.Document.GetElement(element.GetTypeId()).LookupParameter(Name);
          if (parameter?.IsShared ?? false)
          {
            Guid = parameter.GUID;
          }
          else
          {
            return parameter;
          }
        }
        if (Name == null || Name == "")
        {
          parameter = element.get_Parameter(Guid);
          Name = parameter.Definition.Name;
        }
        return parameter;
      }
      catch
      {
        string pgName = Name ?? Guid.ToString();
        throw new Exception($"Отсутствует параметр '{pgName}'. у элемента '{element.Id}'"); // TODO      
      }
    }
  }



}
