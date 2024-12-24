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

    protected override void DataBind()
    {
        IReadOnlyCollection<SalesView> entities = _salesService.List(_restaurantId, From, To);
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
        var view = new SalesWindow(ServiceProvider, _restaurantId, saleId: null);
        WindowHelper.ShowDialog(view, "Создание записи", 500, 500);
        DataBind();
    }

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