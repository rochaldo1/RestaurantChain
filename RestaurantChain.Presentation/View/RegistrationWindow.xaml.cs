﻿using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Логика взаимодействия для RegistrationWindow.xaml
/// </summary>
public partial class RegistrationWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
        
    public RegistrationWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
            
        InitializeComponent();
        var usersService = serviceProvider.GetRequiredService<IUsersService>();
        DataContext = new RegistrationViewModel(usersService);
        if (DataContext is RegistrationViewModel registrationViewModel)
        {
            registrationViewModel.OnRegistrationSuccess += RegistrationSuccess;
        }
        PreviewKeyDown += PreviewKeyDownHandle;
    }

    public void RegistrationSuccess()
    {
        MessageBox.Show("Вы успешно зарегестрировались!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        {
            ((RegistrationViewModel)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
        }
    }

    private void PasswordBox_VerificationPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        {
            ((RegistrationViewModel)this.DataContext).VerificationPassword = ((PasswordBox)sender).SecurePassword;
        }
    }
        
    private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                Close();

                break;
            case Key.Enter:
                (DataContext as RegistrationViewModel)?.Enter(this);

                break;
        }
    }
}