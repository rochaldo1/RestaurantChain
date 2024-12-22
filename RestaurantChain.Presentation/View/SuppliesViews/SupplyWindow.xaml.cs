using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.SuppliesViewModel;

namespace RestaurantChain.Presentation.View.SuppliesViews;

/// <summary>
/// Interaction logic for SupplyWindow.xaml
/// </summary>
public partial class SupplyWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public SupplyWindow(IServiceProvider serviceProvider, int? supplyId)
    {
        var productsService = serviceProvider.GetRequiredService<IProductsService>();
        var suppliesService = serviceProvider.GetRequiredService<ISuppliesService>();
        var suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();

        InitializeComponent();
        DataContext = new SupplyViewModel(suppliersService, productsService, suppliesService, supplyId);
        if (DataContext is SupplyViewModel vm)
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