using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.ApplicationsForDistributionViewModel;

internal class ApplicationViewModel : EditViewModelBase
{
    private readonly IApplicationsForDistributionService _applicationsForDistributionService;
    private readonly IProductsService _productsService;
    private readonly IAvailibilityInRestaurantService _availibilityInRestaurantService;

    private int _restaurantId;
    private IReadOnlyCollection<ProductsView> _productsDataSource;
    private int _selectedProductId;
    private DateTime _applicationDate;
    private int _quantity;
    private string _unit;
    private decimal _price;

    /// <summary>
    /// Модель данных. Продукты
    /// </summary>
    public IReadOnlyCollection<ProductsView> ProductsDataSource
    {
        get => _productsDataSource;
        set
        {
            _productsDataSource = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Дата заявки
    /// </summary>
    public DateTime ApplicationDate
    {
        get => _applicationDate;
        set
        {
            _applicationDate = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Единица измерения
    /// </summary>
    public string Unit
    {
        get => _unit;
        set
        {
            _unit = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Количество
    /// </summary>
    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Цена
    /// </summary>
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Выбранный продукт
    /// </summary>
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

    public ApplicationViewModel
    (
        IApplicationsForDistributionService applicationsForDistributionService,
        IProductsService productsService,
        IAvailibilityInRestaurantService availibilityInRestaurantService,
        int? currentId,
        int restaurantId
    ) : base(currentId)
    {
        _applicationsForDistributionService = applicationsForDistributionService;
        _productsService = productsService;
        _availibilityInRestaurantService = availibilityInRestaurantService;
        _restaurantId = restaurantId;

        if (!Validate())
        {
            OnCancel.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
    public override bool Validate()
    {
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

    /// <summary>
    /// Обработка команды нажатия кнопки сохранения данных
    /// </summary>
    /// <param name="sender"></param>
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

    /// <summary>
    ///  Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
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

    /// <summary>
    ///  Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create(ApplicationsForDistribution application)
    {
        _applicationsForDistributionService.Create(application);

        _availibilityInRestaurantService.Create(new AvailibilityInRestaurant
        {
            ProductId = application.ProductId,
            RestaurantId = application.RestaurantId,
            Price = application.Price,
            Quantity = application.Quantity,
            UnitId = application.UnitId,
        });
        
        return true;
    }

    /// <summary>
    /// Провалидировать и получить модель для сохранения
    /// </summary>
    /// <returns></returns>
    private ApplicationsForDistribution ValidateAndGetModelOnSave()
    {
        if (_selectedProductId <= 0)
        {
            MessageBox.Show($"Продукт не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var product = _productsDataSource.FirstOrDefault(x => x.Id == _selectedProductId);

        var application = new ApplicationsForDistribution
        {
            Id = CurrentId ?? 0,
            ProductId = _selectedProductId,
            RestaurantId = _restaurantId,
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