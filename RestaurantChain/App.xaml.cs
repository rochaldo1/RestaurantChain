using RestaurantChain.Model;
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


            app.Run();
        }
    }

}
