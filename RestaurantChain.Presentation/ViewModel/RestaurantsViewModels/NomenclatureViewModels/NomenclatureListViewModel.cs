using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

internal sealed class NomenclatureListViewModel : ListViewModelBase<NomenclatureView>
{
    private readonly INomenclatureService _nomenclatureService;

    private readonly int _restaurantId;

    public NomenclatureListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _nomenclatureService = serviceProvider.GetRequiredService<INomenclatureService>();
        OnPropertyChanged();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<NomenclatureView> entities = _nomenclatureService.List(_restaurantId);
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
        var view = new NomenclatureWindow(ServiceProvider, _restaurantId, nomenclatureId: null);
        WindowHelper.ShowDialog(view, "Добавление записи", width: 550, height: 200);
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

        var view = new NomenclatureWindow(ServiceProvider, _restaurantId, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", width: 550, height: 200);
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

        if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _nomenclatureService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}