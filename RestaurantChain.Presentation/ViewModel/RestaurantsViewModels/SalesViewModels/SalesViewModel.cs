using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

internal sealed class SalesViewModel: EditViewModelBase
{
    private readonly ISalesService _salesService;
    private readonly IDishesService _dishesService;
    private readonly INomenclatureService _nomenclatureService;

    private int _restaurantId;
    private IReadOnlyCollection<NomenclatureView> _dishesDataSource;
    private DateTime _saleDate;
    private int _selectedDishId;
    private int _quantity;
    private string _price;
    private string _groupName;

    public IReadOnlyCollection<NomenclatureView> DishesDataSource
    {
        get => _dishesDataSource;
        set
        {
            _dishesDataSource = value;
            OnPropertyChanged();
        }
    }

    public DateTime SaleDate
    {
        get => _saleDate;
        set
        {
            _saleDate = value;
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

    public string Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public int SelectedDishId
    {
        get => _selectedDishId;
        set
        {
            if (_selectedDishId != value && value > 0)
            {
                _selectedDishId = value;
                var dish = DishesDataSource.First(x => x.DishId == _selectedDishId);
                Price = dish.Price.ToString();
                GroupName = dish.GroupName;
            }
        }
    }

    public string GroupName
    {
        get => _groupName;
        set
        {
            _groupName = value;
            OnPropertyChanged();
        }
    }

    public SalesViewModel(IServiceProvider serviceProvider, int restaurantId, int? currentId) : base(currentId)
    {
        _restaurantId = restaurantId;
        _salesService = serviceProvider.GetRequiredService<ISalesService>();
        _dishesService = serviceProvider.GetRequiredService<IDishesService>();
        _nomenclatureService = serviceProvider.GetRequiredService<INomenclatureService>();

        if (!Validate())
        {
            OnCancel.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public override bool Validate()
    {
        DishesDataSource = _nomenclatureService.List(_restaurantId);

        if (CurrentId.HasValue)
        {
            var sale = _salesService.Get(CurrentId.Value);

            if (sale == null)
            {
                MessageBox.Show("���������� � ������� �� ����������!", "������", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            SelectedDishId = sale.DishId;
            SaleDate = sale.SaleDate;
            Quantity = sale.Quantity;
            Price = DishesDataSource.First(x => x.DishId == SelectedDishId).Price.ToString();
            GroupName = DishesDataSource.First(x => x.DishId == SelectedDishId).GroupName;
        }
        else
        {
            SaleDate = DateTime.Now;
        }

        return true;
    }

    private void Enter(object sender)
    {
        var sale = ValidateAndGetModelOnSave();

        if (sale == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(sale) : Create(sale);
        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(Sales sale)
    {
        try
        {
            _salesService.Update(sale);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "������ �����", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(Sales sale)
    {
        _salesService.Create(sale);
        return true;
    }

    private Sales ValidateAndGetModelOnSave()
    {
        if (_selectedDishId <= 0)
        {
            MessageBox.Show($"����� �� �������", "������ �����", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var dish = _dishesDataSource.FirstOrDefault(x => x.DishId == _selectedDishId);

        var sale = new Sales
        {
            Id = CurrentId ?? 0,
            DishId = _selectedDishId,
            RestaurantId = _restaurantId,
            Quantity = _quantity,
            Price = dish.Price,
            SaleDate = _saleDate
        };

        var errors = new List<string>();

        if (sale.DishId <= 0)
        {
            errors.Add("�����");
        }

        if (sale.Quantity < 0)
        {
            errors.Add("����������");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"���� �� ���������: {string.Join(",", errors)}", "������ �����", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return sale;
    }
}