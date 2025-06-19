using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



namespace ARprojBase
{
  public class DebugID
  {
    private static List<int> collection = new List<int>();

    public static void Clear()
    {
      collection = new List<int>();
    }

    public static int Count()
    {
      return collection.Count();
    }

    public static void Add(int Value)
    {
      collection.Add(Value);
    }

    public static void Add(ElementId elementId)
    {
      collection.Add(elementId.IntegerValue);
    }

    public static void Add(Element element)
    {
      collection.Add(element.Id.IntegerValue);
    }


    public static bool IsCheck(int Value)
    {
      if (collection.Any())
      {
        return collection.Contains(Value);
      }
      return false;
    }

    public static bool IsCheck(ElementId elementId)
    {
      return IsCheck(elementId.IntegerValue);
    }

    public static bool IsCheck(Element element)
    {
      return IsCheck(element.Id.IntegerValue);
    }


    public static void Break()
    {
      // Выход из подпрограммы Shift+F11
      // TIPS use Shift+F11 
      Debugger.Break();
    }


    public static void Break(int Value)
    {
      if (collection.Any())
      {
        if (collection.Contains(Value))
        {
          // Выход из подпрограммы Shift+F11
          // TIPS use Shift+F11 
          Debugger.Break();
        }
      }
    }

    public static void Break(ElementId Value)
    {
      if (collection.Any())
      {
        if (collection.Contains(Value.IntegerValue))
        {
          // Выход из подпрограммы Shift+F11
          // TIPS use Shift+F11 
          Debugger.Break();
        }
      }
    }

    public static void Break(Element Value)
    {
      if (collection.Any())
      {
        if (collection.Contains(Value.Id.IntegerValue))
        {
          // Выход из подпрограммы Shift+F11
          // TIPS use Shift+F11 
          Debugger.Break();
        }
      }
    }


    public static void Throw(int Value)
    {
      try
      {
        if (collection.Any())
        {
          if (collection.Contains(Value))
          {
            throw new System.ArgumentException($"Исключение для остановки в Debug {nameof(Value)}", Value.ToString());
          }
        }
      }
      catch
      {
      }
    }



    public static void Throw(Element Value)
    {
      try
      {
        if (collection.Any())
        {
          if (collection.Contains(Value.Id.IntegerValue))
          {
            throw new System.ArgumentException($"Исключение для остановки в Debug {nameof(Value)}", Value.ToString());
          }
        }
      }
      catch
      {
      }
    }


    public static void Throw(ElementId Value)
    {
      try
      {
        if (collection.Any())
        {
          if (collection.Contains(Value.IntegerValue))
          {
            throw new System.ArgumentException($"Исключение для остановки в Debug {nameof(Value)}", Value.ToString());
          }
        }
      }
      catch
      {
      }
    }

  }
}
