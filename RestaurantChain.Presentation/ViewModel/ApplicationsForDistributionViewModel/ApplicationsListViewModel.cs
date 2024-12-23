using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using ApplicationWindow = RestaurantChain.Presentation.View.RestaurantsViews.ApplicationsForDistributionViews.ApplicationWindow;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;

internal class ApplicationsListViewModel : ListViewModelBase<ApplicationsForDistributionView>
{
    private readonly IApplicationsForDistributionService _applicationsForDistributionService;
    private readonly IProductsService _productsService;

    private int _restaurantId;
    private DateTime _from;
    private DateTime _to;

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

    public ApplicationsListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _from = DateTime.Now.AddMonths(-1);
        _to = DateTime.Now;
        _applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
        _productsService = serviceProvider.GetRequiredService<IProductsService>();

        OnPropertyChanged();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<ApplicationsForDistributionView> entities = _applicationsForDistributionService.List(_restaurantId, From, To);
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