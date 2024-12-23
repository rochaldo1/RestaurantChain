using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.AvailibilityInRestaurantViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.AvailibilityInRestaurantViews;

/// <summary>
/// Логика взаимодействия для AvailibilityInRestaurantWindow.xaml
/// </summary>
public partial class AvailibilityInRestaurantWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public AvailibilityInRestaurantWindow(IServiceProvider serviceProvider, int? availibilityId)
    {
        var availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();
        var productsService = serviceProvider.GetRequiredService<IProductsService>();
        var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();

        InitializeComponent();
        DataContext = new AvailibilityViewModel(availibilityInRestaurantService, productsService, restaurantsService, availibilityId);
        if (DataContext is AvailibilityViewModel vm)
        {
            vm.OnSaveSuccess += SaveSuccess;
            vm.OnCancel += SaveError;
        }
    }

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        ((Window)Parent).Close();
    }

    public void SaveSuccess()
    {
        IsSuccess = true;
        ((Window)Parent).Close();
    }

    public void SaveError()
    {
        IsSuccess = false;
        ((Window)Parent).Close();
    }
}