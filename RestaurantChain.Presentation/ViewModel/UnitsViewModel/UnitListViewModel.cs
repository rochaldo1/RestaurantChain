using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.UnitsViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UnitsViewModel;

internal class UnitListViewModel : ListViewModelBase<Units>
{
    private readonly IUnitsService _unitsService;

    public UnitListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _unitsService = serviceProvider.GetRequiredService<IUnitsService>();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<Units> entities = _unitsService.List();
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
        var view = new UnitWindow(ServiceProvider, unitId: null);
        ShowDialog(view, "Создание записи");
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
            
        var view = new UnitWindow(ServiceProvider, SelectedItem.Id);
        ShowDialog(view, "Редактирование записи");
        RefreshData(sender);
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
            
        Units unit = _unitsService.Get(SelectedItem.Id);

        if (MessageBox.Show($"Удалить единицу измерения '{unit.UnitName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _unitsService.Delete(SelectedItem.Id);
        }
        else
        {
            return ;
        }

        RefreshData(sender);
    }

    private void RefreshData(object sender)
    {
        DataBind();
    }
}