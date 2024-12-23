using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.Reports;

internal sealed class GetDishesSumByPeriodViewModel : ReportsViewModelBase
{
    public GetDishesSumByPeriodViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override void Enter(object sender)
    {
        var fileName = _reportsService.GetDishesSumByPeriod(From, To);
        ExcelHelper.OpenExcel(fileName);
    }
}