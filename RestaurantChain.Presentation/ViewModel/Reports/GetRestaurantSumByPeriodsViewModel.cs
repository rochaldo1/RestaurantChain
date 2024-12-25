using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.Reports;

internal sealed class GetRestaurantSumByPeriodsViewModel(IServiceProvider serviceProvider) : ReportsViewModelBase(serviceProvider)
{
    /// <summary>
    /// Операция ввода, выгрузить данные в эксель
    /// </summary>
    /// <param name="sender"></param>
    protected override void Enter(object sender)
    {
        var fileName = _reportsService.GetRestaurantSumByPeriods(From, To);
        ExcelHelper.OpenExcel(fileName);
    }
}