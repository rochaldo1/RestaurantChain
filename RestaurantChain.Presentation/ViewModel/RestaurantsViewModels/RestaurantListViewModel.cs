using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;

public class RestaurantListViewModel : ListViewModelBase<Restaurants>
{
    private readonly IRestaurantsService _restaurantService;

    public RestaurantListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _restaurantService = serviceProvider.GetRequiredService<IRestaurantsService>();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<Restaurants> entities = _restaurantService.List();
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
        var view = new RestaurantWindow(ServiceProvider, restaurantId: null);
        ShowDialog(view, "Создание записи", 500, 500);
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new RestaurantWindow(ServiceProvider, SelectedItem.Id);
        ShowDialog(view, "Редактирование записи", 500, 500);
        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        Restaurants retstaurant = _restaurantService.Get(SelectedItem.Id);
        if (MessageBox.Show($"Удалить поставщика '{retstaurant.RestaurantName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _restaurantService.Delete(SelectedItem.Id);
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