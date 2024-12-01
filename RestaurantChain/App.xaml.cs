using RestaurantChain.Model;
using RestaurantChain.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RestaurantChain
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main()
        {
            App app = new App();
            // TODO: Инжекция репозиториев через DataManager (как только репы появятся)
            LoginWindow window = new LoginWindow();
            app.Run(window);
        }
    }

}
