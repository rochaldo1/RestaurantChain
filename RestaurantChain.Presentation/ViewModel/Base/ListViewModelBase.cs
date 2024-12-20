using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RestaurantChain.Presentation.ViewModel.Base;

public abstract class ListViewModelBase<TEntity> : ViewModelBase
    where TEntity : class
{
    private IReadOnlyCollection<TEntity> _dataSource;
    private TEntity _selectedItem;

    public IReadOnlyCollection<TEntity> DataSource
    {
        get => _dataSource;
        set
        {
            _dataSource = value;
            OnPropertyChanged();
        }
    }

    public TEntity SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    protected IServiceProvider ServiceProvider { get; private set; }
    public ICommand CreateCommand { get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    protected ListViewModelBase(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        SetCommands();
    }

    protected void SetEntities(IReadOnlyCollection<TEntity> dataSource)
    {
        DataSource = dataSource;
    }

    protected abstract void DataBind();
    protected abstract void SetCommands();

    protected static void ShowDialog(UserControl control, string title, int width = 300, int height = 200)
    {
        var window = new Window
        {
            Content = control,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            ResizeMode = ResizeMode.NoResize,
            Width = width,
            Height = height,
            Title = title
        };
        window.ShowDialog();
    }

    public bool HasSelectedItem()
    {
        return _selectedItem != null;
    }
}