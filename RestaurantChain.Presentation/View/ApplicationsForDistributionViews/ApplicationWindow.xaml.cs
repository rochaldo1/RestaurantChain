using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.ApplicationsForDistributionViews;

/// <summary>
/// Логика взаимодействия для ApplicationWindow.xaml
/// </summary>
public partial class ApplicationWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public ApplicationWindow(IServiceProvider serviceProvider, int? applicationId)
    {
        var applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
        var productsService = serviceProvider.GetRequiredService<IProductsService>();
        var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();

        InitializeComponent();
        DataContext = new ApplicationViewModel(applicationsForDistributionService, productsService, restaurantsService, applicationId);
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