using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.ApplicationsForDistributionViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;

internal class ApplicationsListViewModel : ListViewModelBase<ApplicationsForDistributionView>
{
    private readonly IApplicationsForDistributionService _applicationsForDistributionService;
    private readonly IProductsService _productsService;

    private int _selectedRestaurantId;
    private DateTime _from;
    private DateTime _to;
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

    public DateTime From
    {
        get => _from;
        set
        {
            _from = value;
            OnPropertyChanged();
        }
    }

    public DateTime To
    {
        get => _to;
        set
        {
            _to = value;
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

    public ApplicationsListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _from = DateTime.Now.AddMonths(-1);
        _to = DateTime.Now;
        _applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
        _productsService = serviceProvider.GetRequiredService<IProductsService>();

        var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();
        RestaurantsDataSource = restaurantsService.List();

        OnPropertyChanged();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<ApplicationsForDistributionView> entities = _applicationsForDistributionService.List(SelectedRestaurantId, From, To);
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
        var view = new ApplicationWindow(ServiceProvider, applicationId: null);
        ShowDialog(view, "Создание записи", 500, 500);
        DataBind();
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new ApplicationWindow(ServiceProvider, SelectedItem.Id);
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
            var supplies = _applicationsForDistributionService.Get(SelectedItem.Id);
            _applicationsForDistributionService.Delete(SelectedItem.Id);
            _productsService.CalculateAndUpdateQuantity(supplies.ProductId);
        }
        else
        {
            return;
        }

        DataBind();
    }
}