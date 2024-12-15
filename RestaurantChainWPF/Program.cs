using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChainWPF
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices((context, services) =>
            {
                string connectionString = "server=localhost;database=restaurant_chain;userid=postgres;password=228420;";
                //string connectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=228420;Protocol=3;SSL=false;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=restaurant_chain";
                services.UseStorage(connectionString);
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
            // получаем сервис - объект класса App
            var app = host.Services.GetService<App>();
            // запускаем приложения
            app?.Run();
        }
    }
}
