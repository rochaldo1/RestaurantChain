using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

using RestaurantChain.DomainServices;
using RestaurantChain.Infrastructure;

namespace RestaurantChain.Presentation;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices((context, services) =>
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                //string connectionString = "server=localhost;database=restaurant_chain;userid=postgres;password=228420;";
                services.UseStorage(connectionString);

                services.UseDomainServices();
                services.AddSingleton<App>();
            })
            .Build();
        // получаем сервис - объект класса App
        var app = host.Services.GetService<App>();
        // запускаем приложения
        app?.Run();
    }
}