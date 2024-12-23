using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.Reports;

namespace RestaurantChain.Presentation.View.Reports;

public partial class GetDishesSumByPeriodWindow : UserControl
{
    public GetDishesSumByPeriodWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new GetDishesSumByPeriodViewModel(serviceProvider);
    }
}