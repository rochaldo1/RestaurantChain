using System.Windows;
using System.Windows.Controls;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.ApplicationsForDistributionViewModel;

namespace RestaurantChain.Presentation.View.RestaurantsViews.ApplicationsForDistributionViews;

/// <summary>
/// Логика взаимодействия для ApplicationWindow.xaml
/// </summary>
public partial class ApplicationWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public ApplicationWindow(IServiceProvider serviceProvider, int? applicationId, int restaurantId)
    {
        var applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
        var productsService = serviceProvider.GetRequiredService<IProductsService>();
        var availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();

        InitializeComponent();
        DataContext = new ApplicationViewModel(applicationsForDistributionService, productsService, availibilityInRestaurantService, applicationId, restaurantId);
        if (DataContext is ApplicationViewModel vm)
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