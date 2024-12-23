using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

internal sealed class NomenclatureListViewModel : ListViewModelBase<NomenclatureView>
{
    private readonly INomenclatureService _nomenclatureService;

    private readonly int _restaurantId;

    public NomenclatureListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _nomenclatureService = serviceProvider.GetRequiredService<INomenclatureService>();
        OnPropertyChanged();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<NomenclatureView> entities = _nomenclatureService.List(_restaurantId);
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
        var view = new NomenclatureWindow(ServiceProvider, _restaurantId, nomenclatureId: null);
        WindowHelper.ShowDialog(view, "Добавление записи", width: 550, height: 200);
        DataBind();
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new NomenclatureWindow(ServiceProvider, _restaurantId, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", width: 550, height: 200);
        DataBind();
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show("������� �������?", "�������� ������", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _nomenclatureService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}