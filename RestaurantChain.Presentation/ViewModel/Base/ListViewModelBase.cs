using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.Base;

public abstract class ListViewModelBase<TEntity> : ViewModelBase
    where TEntity : class
{
    public IReadOnlyCollection<TEntity> DataSource { get; private set; }
    protected DataGrid DataGrid { get; private set; }

    public IServiceProvider ServiceProvider { get; private set; }
    public ICommand CreateCommand { get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand RefreshCommand { get; set; }

    protected ListViewModelBase(IServiceProvider serviceProvider, DataGrid _dataGrid)
    {
        DataGrid = _dataGrid;
        ServiceProvider = serviceProvider;
        SetCommands();
    }

    protected void SetEntities(IReadOnlyCollection<TEntity> dataSource)
    {
        DataSource = dataSource;
        DataGrid.ItemsSource = dataSource;
        CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Refresh();
    }

    protected abstract void DataBind();
    protected abstract void SetCommands();

    protected static void ShowDialog(UserControl control, string title ,int width = 300, int height = 200)
    {
        var window = new Window
        {
            Content = control,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            ResizeMode = ResizeMode.NoResize,
            Width = width,
            Height = height,
            Title = title,
            // TODO: Найти какую-нибудь иконку и добавить её тут.
        };
        window.ShowDialog();
    }
}