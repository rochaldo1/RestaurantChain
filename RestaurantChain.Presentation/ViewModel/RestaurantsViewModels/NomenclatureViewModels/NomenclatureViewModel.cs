using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

internal sealed class NomenclatureViewModel : EditViewModelBase
{
    private readonly INomenclatureService _nomenclatureService;
    private readonly IDishesService _dihesService;

    private int _restaurantId;
    private IReadOnlyCollection<DishesView> _dishesDataSource;
    private int _selectedDishId;
    private decimal _price;

    public IReadOnlyCollection<DishesView> DishesDataSource
    {
        get => _dishesDataSource;
        set
        {
            _dishesDataSource = value;
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
                var dish = DishesDataSource.First(x => x.Id == _selectedDishId);
                Price = dish.Price;
            }
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

    public NomenclatureViewModel(IServiceProvider serviceProvider, int restaurantId, int? currentId) : base(currentId)
    {
        _nomenclatureService = serviceProvider.GetRequiredService<INomenclatureService>();
        _dihesService = serviceProvider.GetRequiredService<IDishesService>();
        _restaurantId = restaurantId;

        if (!Validate())
        {
            OnCancel.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public override bool Validate()
    {
        DishesDataSource = _dihesService.List();

        if (CurrentId.HasValue)
        {
            var nomenclature = _nomenclatureService.Get(CurrentId.Value);

            if (nomenclature == null)
            {
                MessageBox.Show("Информации о номенклатуре не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            SelectedDishId = nomenclature.DishId;
            Price = DishesDataSource.First(x => x.Id == SelectedDishId).Price;
        }

        return true;
    }

    private void Enter(object sender)
    {
        var nomenclature = ValidateAndGetModelOnSave();

        if (nomenclature == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(nomenclature) : Create(nomenclature);
        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(Nomenclature nomenclature)
    {
        try
        {
            _nomenclatureService.Update(nomenclature);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(Nomenclature nomenclature)
    {
        _nomenclatureService.Create(nomenclature);
        return true;
    }

    private Nomenclature ValidateAndGetModelOnSave()
    {
        if (_selectedDishId <= 0)
        {
            MessageBox.Show($"Блюдо не выбрано", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var dish = _dishesDataSource.FirstOrDefault(x => x.Id == _selectedDishId);

        var nomenclature = new Nomenclature
        {
            Id = CurrentId ?? 0,
            DishId = _selectedDishId,
            RestaurantId = _restaurantId
        };

        var errors = new List<string>();

        if (nomenclature.DishId <= 0)
        {
            errors.Add("Блюдо");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return nomenclature;
    }
}