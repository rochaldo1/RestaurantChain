using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.AvailibilityInRestaurantViewModel;

namespace RestaurantChain.Presentation.View.RestaurantsViews.AvailibilityInRestaurantViews;

/// <summary>
/// Логика взаимодействия для AvailibilityInRestaurantWindow.xaml
/// </summary>
public partial class AvailibilityInRestaurantWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public AvailibilityInRestaurantWindow(IServiceProvider serviceProvider, int? availibilityId, int restaurantId)
    {
        var availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();
        var productsService = serviceProvider.GetRequiredService<IProductsService>();

        InitializeComponent();
        DataContext = new AvailibilityViewModel(availibilityInRestaurantService, productsService, availibilityId, restaurantId);
        if (DataContext is AvailibilityViewModel vm)
        {
            vm.OnSaveSuccess += SaveSuccess;
            vm.OnCancel += SaveError;
        }

        KeyDown += PreviewKeyDownHandle;
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
    
    private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                ((Window)Parent).Close();
                break;
        }
    }
}