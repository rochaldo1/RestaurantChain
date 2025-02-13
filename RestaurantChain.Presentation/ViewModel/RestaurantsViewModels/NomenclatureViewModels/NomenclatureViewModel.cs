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

    /// <summary>
    /// Модель данных. Список блюд
    /// </summary>
    public IReadOnlyCollection<DishesView> DishesDataSource
    {
        get => _dishesDataSource;
        set
        {
            _dishesDataSource = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Выбранное блюдо
    /// </summary>
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

    /// <summary>
    /// Модель данных. Стоимость
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

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
    public override bool Validate()
    {
        DishesDataSource = _dihesService.List();

        if (CurrentId.HasValue)
        {
            var nomenclature = _nomenclatureService.Get(CurrentId.Value);

            if (nomenclature == null)
            {
                MessageBox.Show("Номенклатура не найдена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            SelectedDishId = nomenclature.DishId;
            Price = DishesDataSource.First(x => x.Id == SelectedDishId).Price;
        }

        return true;
    }

    /// <summary>
    /// Обработка команды нажатия кнопки сохранения данных
    /// </summary>
    /// <param name="sender"></param>
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

    /// <summary>
    ///  Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
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

    /// <summary>
    ///  Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create(Nomenclature nomenclature)
    {
        _nomenclatureService.Create(nomenclature);
        return true;
    }

    /// <summary>
    /// Провалидировать и получить модель для сохранения
    /// </summary>
    /// <returns></returns>
    private Nomenclature ValidateAndGetModelOnSave()
    {
        if (_selectedDishId <= 0)
        {
            MessageBox.Show($"Блюдо не выбрано", "Редактирование записи", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var nomenclature = new Nomenclature
        {
            Id = CurrentId ?? 0,
            DishId = _selectedDishId,
            RestaurantId = _restaurantId
        };

        var errors = new List<string>();

        if (nomenclature.DishId <= 0)
        {
            errors.Add("блюдо");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Ошибки: {string.Join(",", errors)}", "Ошибки ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return nomenclature;
    }
}