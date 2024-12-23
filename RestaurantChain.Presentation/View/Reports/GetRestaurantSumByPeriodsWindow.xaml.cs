using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.Reports;

namespace RestaurantChain.Presentation.View.Reports;

public partial class GetRestaurantSumByPeriodsWindow : UserControl
{
    public GetRestaurantSumByPeriodsWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new GetRestaurantSumByPeriodsViewModel(serviceProvider);
    }
}