using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.AvailibilityInRestaurantViewModel;

internal class AvailibilityViewModel : EditViewModelBase
{
    private readonly IAvailibilityInRestaurantService _availibilityInRestaurantService;
    private readonly IProductsService _productsService;
    private readonly IRestaurantsService _restaurantsService;

    private IReadOnlyCollection<ProductsView> _productsDataSource;
    private IReadOnlyCollection<Restaurants> _restaurantsDataSource;
    private int _selectedProductId;
    private int _selectedRestaurantId;
    private int _quantity;
    private string _unit;
    private decimal _price;

    public IReadOnlyCollection<ProductsView> ProductsDataSource
    {
        get => _productsDataSource;
        set
        {
            _productsDataSource = value;
            OnPropertyChanged();
        }
    }

    public IReadOnlyCollection<Restaurants> RestaurantsDataSource
    {
        get => _restaurantsDataSource;
        set
        {
            _restaurantsDataSource = value;
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
                var product = ProductsDataSource.First(x => x.Id == _selectedProductId);
                Price = product.Price;
                Unit = product.UnitName;
            }
        }
    }

    public int SelectedRestaurantId
    {
        get => _selectedRestaurantId;
        set
        {
            _selectedRestaurantId = value;
            OnPropertyChanged();
        }
    }

    public AvailibilityViewModel
    (
        IAvailibilityInRestaurantService availibilityInRestaurantService, 
        IProductsService productsService, 
        IRestaurantsService restaurantsService, 
        int? currentId
    ) : base(currentId)
    {
        _availibilityInRestaurantService = availibilityInRestaurantService;
        _productsService = productsService;
        _restaurantsService = restaurantsService;

        if (!Validate())
        {
            OnCancel.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public override bool Validate()
    {
        RestaurantsDataSource = _restaurantsService.List();
        ProductsDataSource = _productsService.List();

        if (CurrentId.HasValue)
        {
            var availibility = _availibilityInRestaurantService.Get(CurrentId.Value);

            if (availibility == null)
            {
                MessageBox.Show("Информации о наличии продукта не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            SelectedProductId = availibility.ProductId;
            SelectedRestaurantId = availibility.RestaurantId;
            Quantity = availibility.Quantity;
            Price = availibility.Price;
            Unit = availibility.UnitName;
        }

        return true;
    }

    private void Enter(object sender)
    {
        var availibility = ValidateAndGetModelOnSave();

        if (availibility == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(availibility) : Create(availibility);
        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(AvailibilityInRestaurant availibility)
    {
        try
        {
            _availibilityInRestaurantService.Update(availibility);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(AvailibilityInRestaurant availibility)
    {
        _availibilityInRestaurantService.Create(availibility);
        return true;
    }

    private AvailibilityInRestaurant ValidateAndGetModelOnSave()
    {
        if (_selectedProductId <= 0)
        {
            MessageBox.Show($"Продукт не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (_selectedRestaurantId <= 0)
        {
            MessageBox.Show($"Ресторан не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var product = _productsDataSource.FirstOrDefault(x => x.Id == _selectedProductId);

        var availibility = new AvailibilityInRestaurant
        {
            Id = CurrentId ?? 0,
            ProductId = _selectedProductId,
            RestaurantId = _selectedRestaurantId,
            Quantity = _quantity,
            Price = product.Price,
            UnitId = product.UnitId
        };

        var errors = new List<string>();

        if (availibility.ProductId <= 0)
        {
            errors.Add("Продукт");
        }

        if (availibility.Quantity < 0)
        {
            errors.Add("Количество");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return availibility;
    }
}