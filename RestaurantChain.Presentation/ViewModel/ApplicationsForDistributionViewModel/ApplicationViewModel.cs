using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;

internal class ApplicationViewModel : EditViewModelBase
{
    private readonly IApplicationsForDistributionService _applicationsForDistributionService;
    private readonly IProductsService _productsService;
    private readonly IRestaurantsService _restaurantsService;

    private IReadOnlyCollection<ProductsView> _productsDataSource;
    private IReadOnlyCollection<Restaurants> _restaurantsDataSource;
    private int _selectedProductId;
    private int _selectedRestaurantId;
    private DateTime _applicationDate;
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

    public DateTime ApplicationDate
    {
        get => _applicationDate;
        set
        {
            _applicationDate = value;
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

    public ApplicationViewModel
    (
        IApplicationsForDistributionService applicationsForDistributionService, 
        IProductsService productsService, 
        IRestaurantsService restaurantsService, 
        int? currentId
    ) : base(currentId)
    {
        _applicationsForDistributionService = applicationsForDistributionService;
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
            var application = _applicationsForDistributionService.Get(CurrentId.Value);

            if (application == null)
            {
                MessageBox.Show("Заявки не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            SelectedProductId = application.ProductId;
            SelectedRestaurantId = application.RestaurantId;
            ApplicationDate = application.ApplicationDate;
            Quantity = application.Quantity;
            Price = application.Price;
            Unit = application.UnitName;
        }
        else
        {
            ApplicationDate = DateTime.Now;
        }
        
        return true;
    }

    private void Enter(object sender)
    {
        var application = ValidateAndGetModelOnSave();

        if (application == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(application) : Create(application);
        if (result)
        {
            _productsService.CalculateAndUpdateQuantity(application.ProductId);
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(ApplicationsForDistribution application)
    {
        try
        {
            _applicationsForDistributionService.Update(application);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(ApplicationsForDistribution application)
    {
        _applicationsForDistributionService.Create(application);
        return true;
    }

    private ApplicationsForDistribution ValidateAndGetModelOnSave()
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

        var application = new ApplicationsForDistribution
        {
            Id = CurrentId ?? 0,
            ProductId = _selectedProductId,
            RestaurantId = _selectedRestaurantId,
            Quantity = _quantity,
            Price = product.Price,
            UnitId = product.UnitId,
            ApplicationDate = _applicationDate,
        };

        var errors = new List<string>();

        if (application.ProductId <= 0)
        {
            errors.Add("Продукт");
        }

        if (application.Quantity < 0)
        {
            errors.Add("Количество");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (product.Quantity < application.Quantity)
        {
            MessageBox.Show("Количество продуктов в заявке не может быть больше, чем количество продуктов на центральном складе", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return application;
    }
}