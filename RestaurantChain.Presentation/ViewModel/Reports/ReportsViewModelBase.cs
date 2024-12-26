using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.Reports;

/// <summary>
/// Базовый класс для VM отчетов
/// У нас всегда в отчетах есть дата с и дата по
/// а так же сервис отчетов обязателен
/// И кнопка ОК - сформировать документ
/// </summary>
internal abstract class ReportsViewModelBase : ViewModelBase
{
    protected readonly IReportsService _reportsService;
    private DateTime _from;
    private DateTime _to;
    
    /// <summary>
    /// Обработчик команды кнопки ОК
    /// </summary>
    public ICommand EnterCommand { get; set; }

    /// <summary>
    /// Дата с
    /// </summary>
    public DateTime From
    {
        get => _from;
        set
        {
            _from = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Дата по
    /// </summary>
    public DateTime To
    {
        get => _to;
        set
        {
            _to = value;
            OnPropertyChanged();
        }
    }

    protected ReportsViewModelBase(IServiceProvider serviceProvider)
    {
        _reportsService = serviceProvider.GetRequiredService<IReportsService>();

        From = DateTime.Today;
        To = DateTime.Today;
        EnterCommand = new RelayCommand(Enter);
    }

    /// <summary>
    /// Обработчик команды ОК
    /// </summary>
    /// <param name="sender"></param>
    protected abstract void Enter(object sender);
}