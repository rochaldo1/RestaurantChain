using System.Windows.Controls;

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
        
        InitializeComponent();
        DataContext = new SalesViewModel(serviceProvider, restaurantId, saleId);
    }
}