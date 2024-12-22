using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.Commands;

namespace RestaurantChain.Presentation.ViewModel.SuppliesViewModel;

internal class SupplyViewModel : EditViewModelBase
{
    private readonly IProductsService _productsService;
    private readonly ISuppliesService _suppliesService;
    private readonly ISuppliersService _suppliersService;

    private IReadOnlyCollection<ProductsView> _productsDataSource;
    private IReadOnlyCollection<Suppliers> _suppliersDataSource;
    private int _selectedProductId;
    private int _selectedSupplierId;
    private DateTime _supplyDate;
    private int _quantity;
    private string _unit;
    private decimal _price;

    public IReadOnlyCollection<Suppliers> SuppliersDataSource
    {
        get => _suppliersDataSource;
        set
        {
            _suppliersDataSource = value;
            OnPropertyChanged();
        }
    }

    public IReadOnlyCollection<ProductsView> ProductsDataSource
    {
        get => _productsDataSource;
        set
        {
            _productsDataSource = value;
            OnPropertyChanged();
        }
    }

    public DateTime SupplyDate
    {
        get => _supplyDate;
        set
        {
            _supplyDate = value;
            OnPropertyChanged();
        }
    }

    public string Unit
    {
        get => _unit;
        set
        {
            _unit = value;
            OnPropertyChanged();
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public int SelectedProductId
    {
        get => _selectedProductId;
        set
        {
            if (_selectedProductId != value && value > 0)
            {
                _selectedProductId = value;
                //Выбрали продукт - проставить цену и единицу
                var product = ProductsDataSource.First(x => x.Id == _selectedProductId);
                Price = product.Price;
                Unit = product.UnitName;
            }

            OnPropertyChanged();
        }
    }

    public int SelectedSupplierId
    {
        get => _selectedSupplierId;
        set
        {
            _selectedSupplierId = value;
            OnPropertyChanged();
        }
    }

    public SupplyViewModel
    (
        ISuppliersService suppliersService,
        IProductsService productsService,
        ISuppliesService suppliesService,
        int? currentId
    ) : base(currentId)
    {
        _productsService = productsService;
        _suppliesService = suppliesService;
        _suppliersService = suppliersService;

        if (!Validate())
        {
            OnCancel.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public override bool Validate()
    {
        SuppliersDataSource = _suppliersService.List();
        ProductsDataSource = _productsService.List();

        if (CurrentId.HasValue)
        {
            var supply = _suppliesService.Get(CurrentId.Value);

            if (supply == null)
            {
                MessageBox.Show("Поставки не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            SelectedProductId = supply.ProductId;
            SelectedSupplierId = supply.SupplierId;
            SupplyDate = supply.SupplyDate;
            Quantity = supply.Quantity;
            Price = supply.Price;
            Unit = supply.UnitName;
        }
        else
        {
            SupplyDate = DateTime.Now;
        }

        return true;
    }

    private void Enter(object sender)
    {
        var supply = ValidateAndGetModelOnSave();

        if (supply == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(supply) : Create(supply);

        if (result)
        {
            _productsService.CalculateAndUpdateQuantity(supply.ProductId);
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(Supplies supply)
    {
        try
        {
            _suppliesService.Update(supply);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(Supplies product)
    {
        _suppliesService.Create(product);
        return true;
    }

    private Supplies ValidateAndGetModelOnSave()
    {
        if (_selectedProductId <= 0)
        {
            MessageBox.Show($"Продукт не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (_selectedSupplierId <= 0)
        {
            MessageBox.Show($"Поставщик не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var product = _productsDataSource.FirstOrDefault(x => x.Id == _selectedProductId);

        var supply = new Supplies
        {
            Id = CurrentId ?? 0,
            ProductId = _selectedProductId,
            SupplierId = _selectedSupplierId,
            Quantity = _quantity,
            Price = product.Price,
            UnitId = product.UnitId,
            SupplyDate = _supplyDate,
        };

        var errors = new List<string>();

        if (supply.ProductId <= 0)
        {
            errors.Add("Продукт");
        }

        if (supply.Quantity < 0)
        {
            errors.Add("Количество");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return supply;
    }
}