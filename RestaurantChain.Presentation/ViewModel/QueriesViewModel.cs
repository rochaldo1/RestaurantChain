using System.Data;
using System.Windows;
using System.Windows.Input;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
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
            OnPropertyChanged("Query");
        }
    }

    private DataView _dataSource;
    public DataView DataSource
    {
        get => _dataSource;
        set
        {
            _dataSource = value;
            OnPropertyChanged("DataSource");
        }
    }

    public ICommand EnterCommand { get; }
    private readonly IQueryService _queryService;


    public QueriesViewModel(IQueryService queryService)
    {
        EnterCommand = new RelayCommand(Enter);
        _queryService = queryService;
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