using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;

/// <summary>
/// ������ �������������� ��� SalesWindow.xaml
/// </summary>
public partial class SalesWindow : UserControl
{
    /// <summary>
    /// ��������� ���������� ������.
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