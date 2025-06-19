// Ignore Spelling: Rproj

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ARprojBase
{
  public static class ImageConverter
  {

    public static BitmapImage ToImageSource(this Image image)
    {
      using (var memory = new MemoryStream())
      {
        image.Save(memory, ImageFormat.Png);
        memory.Position = 0L;

        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        return bitmapImage;
      }
    }
  }
}
