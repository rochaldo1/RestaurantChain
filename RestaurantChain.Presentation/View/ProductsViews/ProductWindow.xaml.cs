using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.ProductsViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.ProductsViews;

/// <summary>
/// Логика взаимодействия для ProductWindow.xaml
/// </summary>
public partial class ProductWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public ProductWindow(IServiceProvider serviceProvider, int? productId)
    {
        var productsService = serviceProvider.GetRequiredService<IProductsService>();
        var unitsService = serviceProvider.GetService<IUnitsService>();
        InitializeComponent();
        DataContext = new ProductViewModel(productsService, unitsService, productId);
        if (DataContext is ProductViewModel productViewModel)
        {
            productViewModel.OnSaveSuccess += SaveSuccess;
            productViewModel.OnCancel += SaveError;
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