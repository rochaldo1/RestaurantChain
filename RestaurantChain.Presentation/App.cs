using RestaurantChain.Presentation.View;
using System.Windows;

public class App : Application
{
    readonly LogInWindow logInWindow;

    // через систему внедрения зависимостей получаем объект главного окна
    public App(IServiceProvider serviceProvider)
    {
        logInWindow = new LogInWindow(serviceProvider);
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        var rsrc = "Resources/StyleResources.xaml";
        var currentRsrc = new Uri(rsrc, UriKind.RelativeOrAbsolute);
        Current.Resources.MergedDictionaries.Add(new ResourceDictionary
        {
            Source = currentRsrc
        });
        logInWindow.Show();  // отображаем главное окно на экране
        base.OnStartup(e);
    }
}