using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;

namespace RestaurantChain.Presentation.ViewModel.Reports;

internal abstract class ReportsViewModelBase : ViewModelBase
{
    protected readonly IReportsService _reportsService;

    private DateTime _from;
    private DateTime _to;
    public ICommand EnterCommand { get; set; }

    public DateTime From
    {
        get => _from;
        set
        {
            _from = value;
            OnPropertyChanged();
        }
    }

    public DateTime To
    {
        get => _to;
        set
        {
            _to = value;
            OnPropertyChanged();
        }
    }

    public ReportsViewModelBase(IServiceProvider serviceProvider)
    {
        _reportsService = serviceProvider.GetRequiredService<IReportsService>();

        From = DateTime.Today;
        To = DateTime.Today;
        EnterCommand = new RelayCommand(Enter);
    }

    public abstract void Enter(object sender);
}