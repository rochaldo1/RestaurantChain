using System.Windows;
using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.Base;

/// <summary>
/// Базовый класс для ViewModel для просмотра списков
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class ListViewModelBase<TEntity> : ViewModelBase
    where TEntity : class
{
    private IReadOnlyCollection<TEntity> _dataSource;
    private TEntity _selectedItem;

    /// <summary>
    /// Основной источник данных для таблицы
    /// </summary>
    public IReadOnlyCollection<TEntity> DataSource
    {
        get => _dataSource;
        set
        {
            _dataSource = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Выделенная сушность в таблице
    /// </summary>
    public TEntity SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Сервис провайдер чтоб получать необходимые сервисы в вьюмодели
    /// </summary>
    protected IServiceProvider ServiceProvider { get; private set; }
    
    /// <summary>
    /// Команда создать
    /// </summary>
    public ICommand CreateCommand { get; set; }
    
    /// <summary>
    /// Команда редактировать
    /// </summary>
    public ICommand EditCommand { get; set; }
    
    /// <summary>
    /// Команда удалить
    /// </summary>
    public ICommand DeleteCommand { get; set; }

    protected ListViewModelBase(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        SetCommands();
    }

    /// <summary>
    /// Установка данных для таблицы
    /// </summary>
    /// <param name="dataSource"></param>
    protected void SetEntities(IReadOnlyCollection<TEntity> dataSource)
    {
        DataSource = dataSource;
    }
    
    /// <summary>
    /// Метод для обновления таблицы, чтоб везде было одинаковое обновление таблицы
    /// </summary>
    protected abstract void DataBind();
    
    /// <summary>
    /// Метод установки команд
    /// </summary>
    protected abstract void SetCommands();

    /// <summary>
    /// Есть ли выделенная строка в таблице
    /// </summary>
    /// <returns></returns>
    protected bool HasSelectedItem()
    {
        return _selectedItem != null;
    }

    /// <summary>
    /// Метод, который определяет, пытались ли удалить запись из бд, а на нее есть еще связи FK чтоб вывести нормальную ошибку
    /// </summary>
    /// <param name="exception"></param>
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