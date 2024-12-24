using System.Diagnostics;
using System.IO;
using System.Windows.Media.Imaging;

namespace RestaurantChain.Presentation.Classes.Helpers;

/// <summary>
/// Хэлпер получения иконок из ресурсов
/// </summary>
internal static class IconHelper
{
    /// <summary>
    /// Получить иконку редактирования
    /// </summary>
    /// <returns></returns>
    public static BitmapImage GetEditIcon()
    {
        const string imageUrl = "/Resources/edit.png";

        return GetImage(imageUrl);
    }

    /// <summary>
    /// Получить путь до СОдержания (хэлпа)
    /// </summary>
    /// <returns></returns>
    public static Uri GetHelpUri()
    {
        const string file = "/Resources/help.htm";

        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        return new Uri($"{folder}{file}");
    }

    /// <summary>
    /// Получить картинку по пути
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    private static BitmapImage GetImage(string image)
    {
        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        var source = new Uri($"{folder}{image}");

        return new BitmapImage(source);
    }
}