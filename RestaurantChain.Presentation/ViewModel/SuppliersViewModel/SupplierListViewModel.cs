using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.SuppliersViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.SuppliersViewModel;

public class SupplierListViewModel : ListViewModelBase<Suppliers>
{
    private readonly ISuppliersService _suppliersService;

    public SupplierListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<Suppliers> entities = _suppliersService.List();
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
        var view = new SupplierWindow(ServiceProvider, supplierId: null);
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

        var view = new SupplierWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", 500, 500);
        DataBind();
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        Suppliers supplier = _suppliersService.Get(SelectedItem.Id);
        if (MessageBox.Show($"Удалить поставщика '{supplier.SupplierName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            try
            {
                _suppliersService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }
        }
        else
        {
            return;
        }
        
        DataBind();
    }
}