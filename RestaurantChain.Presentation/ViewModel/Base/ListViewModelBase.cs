using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RestaurantChain.Presentation.Classes.Helpers;

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

    protected bool HasSelectedItem()
    {
        return _selectedItem != null;
    }

    public void IsFkError(Exception exception)
    {
        if (exception.Message.Contains("violates foreign key constraint"))
        {
            MessageBox.Show("Данная запись используется в другой таблице, удалить ее невозможно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            MessageBox.Show($"Произошла ошибка {exception.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}