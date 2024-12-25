using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.ProductsViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.ProductsViewModel;

public class ProductListViewModel : ListViewModelBase<Products>
{
    private readonly IProductsService _productsService;

    public ProductListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _productsService = serviceProvider.GetRequiredService<IProductsService>();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<Products> entities = _productsService.List();
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
        var view = new ProductWindow(ServiceProvider, productId: null);
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
            
        var view = new ProductWindow(ServiceProvider, SelectedItem.Id);
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

        Products product = _productsService.Get(SelectedItem.Id);
        if (MessageBox.Show($"Удалить продукт '{product.ProductName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            try
            {
                _productsService.Delete(SelectedItem.Id);
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