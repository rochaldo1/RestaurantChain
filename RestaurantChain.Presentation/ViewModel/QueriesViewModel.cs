using System.Data;
using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel;

internal class QueriesViewModel : ViewModelBase
{
    private string _query;
    public string Query
    {
        get => _query;
        set
        {
            _query = value;
            OnPropertyChanged();
        }
    }

    private DataTable _dataSource;
    public DataTable DataSource
    {
        get => _dataSource;
        set
        {
            _dataSource = value;
            OnPropertyChanged();
        }
    }

    protected void DataBind()
    {
        try
        {
            DataSource = _queryService.ExecuteQuery(_query);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка запроса! {e.Message}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public ICommand EnterCommand { get; }
    private readonly IQueryService _queryService;
    private readonly QueriesWindow _queriesWindow;
    private readonly IServiceProvider _serviceProvider;

    public QueriesViewModel(IServiceProvider serviceProvider, string sql, QueriesWindow queriesWindow)
    {
        _serviceProvider = serviceProvider;
        _queriesWindow = queriesWindow;
        EnterCommand = new RelayCommand(Enter);
        _queryService = serviceProvider.GetRequiredService<IQueryService>();
        Query = sql;
        DataBind();
    }

    public void Enter(object sender)
    {
        if (string.IsNullOrWhiteSpace(_query))
        {
            MessageBox.Show("Введите запрос!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            DataSource = _queryService.ExecuteQuery(_query);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка запроса! {e.Message}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}