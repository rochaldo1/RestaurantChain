﻿using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;
using System.Windows.Controls;

using RestaurantChain.Presentation.Classes;

namespace RestaurantChain.Presentation.View.RestaurantsViews;

/// <summary>
/// Логика взаимодействия для RestaurantsListWindow.xaml
/// </summary>
public partial class RestaurantsListWindow : UserControl
{
    private readonly IServiceProvider _serviceProvider;
    public RestaurantsListWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        DataContext = new RestaurantListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Рестораны";
    }

    private void Grid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = (DataContext as RestaurantListViewModel).SelectedItem;

        if (item != null)
        {
            mainView.Content = new RestaurantTabsWindow(_serviceProvider, item.Id);
        }
    }
}