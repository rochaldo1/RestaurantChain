using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

internal sealed class SalesListViewModel : ListViewModelBase<SalesView>
{
    private readonly ISalesService _salesService;

    private int _restaurantId;
    private DateTime _from;
    private DateTime _to;
    
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
            DataBind();
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
            DataBind();
        }
    }

    public SalesListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _from = DateTime.Now.AddMonths(-1);
        _to = DateTime.Now;
        _salesService = serviceProvider.GetRequiredService<ISalesService>();
        OnPropertyChanged();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<SalesView> entities = _salesService.List(_restaurantId, From, To);
        SetEntities(entities);
    }

    /// <summary>
    /// Установить команды CRUD кнопкам
    /// </summary>
    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    /// <summary>
    /// Вызов команды создания записи из окна таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void CreateEntity(object sender)
    {
        var view = new SalesWindow(ServiceProvider, _restaurantId, saleId: null);
        WindowHelper.ShowDialog(view, "Создание записи", 500, 500);
        DataBind();
    }

    /// <summary>
    /// Вызов команды редактирования выбранной записи из таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new SalesWindow(ServiceProvider, _restaurantId, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", 500, 500);
        DataBind();
    }

    /// <summary>
    /// Удалить выбранную запись
    /// </summary>
    /// <param name="sender"></param>
    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show($"Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _salesService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}