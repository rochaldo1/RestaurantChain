using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.DishesViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.DishesViewModel;

public class DishListViewModel : ListViewModelBase<Dishes>
{
    private readonly IDishesService _dishesService;

    public DishListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dishesService = serviceProvider.GetRequiredService<IDishesService>();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<Dishes> entities = _dishesService.List();
        SetEntities(entities);
    }

    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    private void CreateEntity(object sender)
    {
        var view = new DishWindow(ServiceProvider, dishId: null);
        ShowDialog(view, "Создание записи", 500, 500);
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new DishWindow(ServiceProvider, SelectedItem.Id);
        ShowDialog(view, "Редактирование записи", 500, 500);
        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        Dishes dish = _dishesService.Get(SelectedItem.Id);
        if (MessageBox.Show($"Удалить блюдо '{dish.DishName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _dishesService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        RefreshData(sender);
    }

    private void RefreshData(object sender)
    {
        DataBind();
    }
}