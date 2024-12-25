using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews.ApplicationsForDistributionViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.ApplicationsForDistributionViewModel;

internal class ApplicationsListViewModel : ListViewModelBase<ApplicationsForDistributionView>
{
    private readonly IApplicationsForDistributionService _applicationsForDistributionService;
    private readonly IProductsService _productsService;
    private readonly IAvailibilityInRestaurantService _availibilityInRestaurantService;

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

    public ApplicationsListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _from = DateTime.Now.AddMonths(-1);
        _to = DateTime.Now;
        _applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
        _productsService = serviceProvider.GetRequiredService<IProductsService>();
        _availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();
        OnPropertyChanged();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<ApplicationsForDistributionView> entities = _applicationsForDistributionService.List(_restaurantId, From, To);
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
        var view = new ApplicationWindow(ServiceProvider, applicationId: null, _restaurantId);
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

        var view = new ApplicationWindow(ServiceProvider, SelectedItem.Id, _restaurantId);
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

        if (MessageBox.Show($"Удалить заявку?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            var application = _applicationsForDistributionService.Get(SelectedItem.Id);
            _applicationsForDistributionService.Delete(SelectedItem.Id);
            _availibilityInRestaurantService.UpdateCount(new AvailibilityInRestaurant
            {
                ProductId = application.ProductId,
                Quantity = application.Quantity,
                Price = application.Price,
                RestaurantId = application.RestaurantId,
                UnitId = application.UnitId,
            });
            _productsService.CalculateAndUpdateQuantity(application.ProductId);
        }
        else
        {
            return;
        }

        DataBind();
    }
}