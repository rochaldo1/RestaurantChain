using System.Windows;
using System.Windows.Controls;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.StreetsViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.StreetsViewModel;

public class StreetListViewModel : ListViewModelBase<Streets>
{
    private readonly IStreetsService _streetsService;

    public StreetListViewModel(IServiceProvider serviceProvider, DataGrid grid) : base(serviceProvider, grid)
    {
        _streetsService = serviceProvider.GetRequiredService<IStreetsService>();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<Streets> entities = _streetsService.List();
        SetEntities(entities);
    }

    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
        RefreshCommand = new RelayCommand(RefreshData);
    }

    private void CreateEntity(object sender)
    {
        var view = new StreetWindow(ServiceProvider, streetId: null);
        ShowDialog(view, "Создание записи");
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (DataGrid.SelectedItem == null)
        {
            return;
        }
        int streetId = ((Streets)DataGrid.SelectedItem).Id;
        var view = new StreetWindow(ServiceProvider, streetId);
        ShowDialog(view, "Редактирование записи");
        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        if (DataGrid.SelectedItem == null)
        {
            return;
        }
        int streetId = ((Streets)DataGrid.SelectedItem).Id;
        Streets street = _streetsService.Get(streetId);

        if (MessageBox.Show($"Удалить улицу '{street.StreetName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _streetsService.Delete(streetId);
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