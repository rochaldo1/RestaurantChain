﻿using RestaurantChain.Presentation.View;
using System.Windows;

public class App : Application
{
    readonly LogInWindow logInWindow;

    // через систему внедрения зависимостей получаем объект главного окна
    public App(IServiceProvider serviceProvider)
    {
        this.logInWindow = new LogInWindow(serviceProvider);
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        logInWindow.Show();  // отображаем главное окно на экране
        base.OnStartup(e);
    }
}