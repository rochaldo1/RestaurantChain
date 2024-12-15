﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantChain.Model;
using RestaurantChain.Storage;
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
            var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices((context, services) =>
            {
                string connectionString = "server=localhost;database=restaurant_chain;uid=root;password=228420;";
                services.UseStorage(connectionString);
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
            // получаем сервис - объект класса App
            var app = host.Services.GetService<App>();
            // запускаем приложения
            app?.Run();

            //App app = new App();
            //LoginWindow window = new LoginWindow();
            //app.Run(window);
        }
    }

}
