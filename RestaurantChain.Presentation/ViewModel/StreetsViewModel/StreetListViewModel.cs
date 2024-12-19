using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.StreetsViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.StreetsViewModel;

internal class StreetListViewModel : ListViewModelBase<Streets>
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
        RefreshCommand = new RelayCommand(RefreshData);
    }

    private void CreateEntity(object sender)
    {
        var view = new StreetWindow(ServiceProvider, streetId: null);
        var window = new Window
        {
            Content = view
        };
        window.ShowDialog();

        if (view.IsSuccess)
        {
            MessageBox.Show("Улица добавлена");
        }

        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        //ТУТ ВЗЯТЬ ID выделенной строки как то
        var streetId = 1;
        var view = new StreetWindow(ServiceProvider, streetId);
        var window = new Window
        {
            Content = view
        };
        window.ShowDialog();

        if (view.IsSuccess)
        {
            MessageBox.Show("Улица обновлена");
        }

        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        //ТУТ ВЗЯТЬ ID выделенной строки как то
        var streetId = 1;

        if (MessageBox.Show("Удалить улицу?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _streetsService.Delete(streetId);
        }

        RefreshData(sender);
    }

    private void RefreshData(object sender)
    {
        DataBind();
    }
}