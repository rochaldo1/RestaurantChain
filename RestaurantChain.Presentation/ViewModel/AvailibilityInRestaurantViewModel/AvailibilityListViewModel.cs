using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.AvailibilityInRestaurantViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.AvailibilityInRestaurantViewModel;

internal class AvailibilityListViewModel : ListViewModelBase<AvailibilityInRestaurantView>
{
    private readonly IAvailibilityInRestaurantService _availibilityInRestaurantService;

    private int _selectedRestaurantId;
    private IReadOnlyCollection<Restaurants> _restaurantsDataSource;

    public int SelectedRestaurantId
    {
        get => _selectedRestaurantId;
        set
        {
            _selectedRestaurantId = value;
            OnPropertyChanged();
        }
    }

    public IReadOnlyCollection<Restaurants> RestaurantsDataSource
    {
        get => _restaurantsDataSource;
        set
        {
            _restaurantsDataSource = value;
            OnPropertyChanged();
        }
    }

    public AvailibilityListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();

        var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();
        RestaurantsDataSource = restaurantsService.List();

        OnPropertyChanged();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<AvailibilityInRestaurantView> entities = _availibilityInRestaurantService.List(SelectedRestaurantId);
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
        var view = new AvailibilityInRestaurantWindow(ServiceProvider, availibilityId: null);
        ShowDialog(view, "Создание записи", 500, 500);
        DataBind();
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new AvailibilityInRestaurantWindow(ServiceProvider, SelectedItem.Id);
        ShowDialog(view, "Редактирование записи", 500, 500);
        DataBind();
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show($"Удалить заявку?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _availibilityInRestaurantService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}