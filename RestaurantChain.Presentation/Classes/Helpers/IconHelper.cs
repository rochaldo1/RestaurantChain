using System.Diagnostics;
using System.IO;
using System.Windows.Media.Imaging;

namespace RestaurantChain.Presentation.Classes.Helpers;

internal static class IconHelper
{
    public static BitmapImage GetListIcon()
    {
        const string imageUrl = "/Resources/database.png";

        return GetImage(imageUrl);
    }

    public static BitmapImage GetEditIcon()
    {
        const string imageUrl = "/Resources/edit.png";

        return GetImage(imageUrl);
    }

    public static Uri GetHelpUri()
    {
        const string file = "/Resources/help.htm";

        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        return new Uri($"{folder}{file}");
    }

    private static BitmapImage GetImage(string image)
    {
        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        var source = new Uri($"{folder}{image}");

        return new BitmapImage(source);
    }
}