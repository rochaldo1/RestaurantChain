using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.SuppliersViewModel;

namespace RestaurantChain.Presentation.View.SuppliersViews;

/// <summary>
/// Логика взаимодействия для SupplierWindow.xaml
/// </summary>
public partial class SupplierWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public SupplierWindow(IServiceProvider serviceProvider, int? supplierId)
    {
        var suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();
        var streetsService = serviceProvider.GetRequiredService<IStreetsService>();
        var banksService = serviceProvider.GetRequiredService<IBanksService>();
        InitializeComponent();
        DataContext = new SupplierViewModel(suppliersService, streetsService, banksService, supplierId);

        if (DataContext is SupplierViewModel supplierViewModel)
        {
            supplierViewModel.OnSaveSuccess += SaveSuccess;
            supplierViewModel.OnCancel += SaveError;
        }

        PreviewKeyDown += PreviewKeyDownHandle;
        Loaded += (sender, args) => { txtBox.Focus(); };
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