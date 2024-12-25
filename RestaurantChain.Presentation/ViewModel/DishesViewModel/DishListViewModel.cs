using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.DishesViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.DishesViewModel;

public class DishListViewModel : ListViewModelBase<Dishes>
{
    private readonly IDishesService _dishesService;

    public DishListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dishesService = serviceProvider.GetRequiredService<IDishesService>();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<Dishes> entities = _dishesService.List();
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
        var view = new DishWindow(ServiceProvider, dishId: null);
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

        var view = new DishWindow(ServiceProvider, SelectedItem.Id);
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

        Dishes dish = _dishesService.Get(SelectedItem.Id);
        if (MessageBox.Show($"Удалить блюдо '{dish.DishName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            try
            {
                _dishesService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }
        }
        else
        {
            return;
        }

        DataBind();
    }
}