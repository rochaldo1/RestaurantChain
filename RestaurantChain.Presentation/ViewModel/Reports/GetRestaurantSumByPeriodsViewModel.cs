using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.Reports;

internal sealed class GetRestaurantSumByPeriodsViewModel : ReportsViewModelBase
{
    public GetRestaurantSumByPeriodsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override void Enter(object sender)
    {
        var fileName = _reportsService.GetRestaurantSumByPeriods(From, To);
        ExcelHelper.OpenExcel(fileName);
    }
}