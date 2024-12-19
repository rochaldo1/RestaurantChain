using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.Base;

internal abstract class ListViewModelBase<TEntity> : ViewModelBase
    where TEntity : class
{
    public IReadOnlyCollection<TEntity> DataSource { get; private set; }

    public IServiceProvider ServiceProvider { get; private set; }
    public ICommand CreateCommand { get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand RefreshCommand { get; set; }

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
}