using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанные со сборкой.
[assembly: AssemblyTitle("LadUnitAll")]
[assembly: AssemblyDescription("Аддон общая часть, используется другими аддонами.")]
[assembly: AssemblyCompany("ООО \"ЛАД\"")]
[assembly: AssemblyProduct("LAD addon")]
[assembly: AssemblyCopyright("ARproj © 2024")]
[assembly: AssemblyTrademark("")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")] // Или "Release"
#else
[assembly: AssemblyConfiguration("Release")] // Или "Release"
#endif

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("a994d188-1859-405e-aaff-5bad19909eeb")]


// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("2022.1.3.0")]
[assembly: NeutralResourcesLanguage("ru-RU")]
