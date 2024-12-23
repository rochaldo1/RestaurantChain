using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;

/// <summary>
/// Логика взаимодействия для SalesWindow.xaml
/// </summary>
public partial class SalesWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public SalesWindow(IServiceProvider serviceProvider,  int restaurantId, int? saleId)
    {
        var salesService = serviceProvider.GetRequiredService<ISalesService>();

        InitializeComponent();
        DataContext = new SalesViewModel(serviceProvider, restaurantId, saleId);
        if (DataContext is SalesViewModel vm)
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