using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.Base;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Domain.Models;
using RestaurantChain.Presentation.View.SuppliesViews;
using System.Windows;

using RestaurantChain.Presentation.Classes.Helpers;

namespace RestaurantChain.Presentation.ViewModel.SuppliesViewModel;

internal class SuppliesListViewModel : ListViewModelBase<SuppliesView>
{
    private readonly ISuppliesService _suppliesService;
    private readonly IProductsService _productsService;

    private int _selectedSupplierId;
    public int SelectedSupplierId
    {
        get => _selectedSupplierId;
        set
        {
            _selectedSupplierId = value;
            OnPropertyChanged();
            DataBind();
        }
    }

    private DateTime _from;
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

    private DateTime _to;
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

    private IReadOnlyCollection<Suppliers> _suppliersDataSource;
    public IReadOnlyCollection<Suppliers> SuppliersDataSource
    {
        get => _suppliersDataSource;
        set
        {
            _suppliersDataSource = value;
            OnPropertyChanged();
        }
    }

    public SuppliesListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _from = DateTime.Now.AddMonths(-1);
        _to = DateTime.Now;
        _suppliesService = serviceProvider.GetRequiredService<ISuppliesService>();
        _productsService = serviceProvider.GetRequiredService<IProductsService>();

        var suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();
        SuppliersDataSource = suppliersService.List();

        OnPropertyChanged();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<SuppliesView> entities = _suppliesService.List(SelectedSupplierId, From, To);
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
        var view = new SupplyWindow(ServiceProvider, supplyId: null);
        WindowHelper.ShowDialog(view, "Создание записи", 500, 500);
        DataBind();
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new SupplyWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", 500, 500);
        DataBind();
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show($"Удалить поставку?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            var supplies = _suppliesService.Get(SelectedItem.Id);

            try
            {
                _suppliesService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }

            _productsService.CalculateAndUpdateQuantity(supplies.ProductId);
        }
        else
        {
            return;
        }

        DataBind();
    }
}