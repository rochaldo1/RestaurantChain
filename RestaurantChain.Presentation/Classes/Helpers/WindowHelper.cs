using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.Classes.Helpers;

internal static class WindowHelper
{
    public static void ShowDialog(UserControl control, string title, int width = 300, int height = 200)
    {
        var window = new Window
        {
            Content = control,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            ResizeMode = ResizeMode.NoResize,
            Width = width,
            Height = height,
            Title = title,
            Icon = IconHelper.GetEditIcon()
        };
        window.ShowDialog();
    }
}