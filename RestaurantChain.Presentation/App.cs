using RestaurantChain.Presentation.View;
using System.Windows;

public class App : Application
{
    readonly LogInWindow logInWindow;

    // через систему внедрения зависимостей получаем объект главного окна
    public App(LogInWindow logInWindow)
    {
        this.logInWindow = logInWindow;
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        logInWindow.Show();  // отображаем главное окно на экране
        base.OnStartup(e);
    }
}