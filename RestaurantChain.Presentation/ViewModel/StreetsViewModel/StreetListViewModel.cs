using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.StreetsViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.StreetsViewModel;

public class StreetListViewModel : ListViewModelBase<Streets>
{
    private readonly IStreetsService _streetsService;

    public StreetListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
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
    }

    private void CreateEntity(object sender)
    {
        var view = new StreetWindow(ServiceProvider, streetId: null);
        WindowHelper.ShowDialog(view, "Создание записи");
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new StreetWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи");
        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
        
        Streets street = _streetsService.Get(SelectedItem.Id);

        if (MessageBox.Show($"Удалить улицу '{street.StreetName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _streetsService.Delete(SelectedItem.Id);
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