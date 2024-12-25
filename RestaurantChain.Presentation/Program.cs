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
        //конфигурация приложения
        var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices((context, services) =>
            {
                //подключить файл с конфигурацией
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                //и получить из него строку подключения
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                
                //Подключить сервис работы с БД UnitOfWork
                services.UseStorage(connectionString);
                //Зарегистрировать серсиы приложения
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