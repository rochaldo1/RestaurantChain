using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RestaurantChain.Presentation.Classes.Helpers;

internal static class ExcelHelper
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public static void OpenExcel(string path)
    {
        var p = new Process();
        p.StartInfo = new ProcessStartInfo(path)
        {
            UseShellExecute = true
        };
        p.Start();

        // Need to wait for excel to start
        p.WaitForInputIdle();

        IntPtr p1 = p.MainWindowHandle;
        ShowWindow(p1, nCmdShow: 1);
    }
}