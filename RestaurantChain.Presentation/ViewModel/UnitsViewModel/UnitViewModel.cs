using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UnitsViewModel;

internal class UnitViewModel : EditViewModelBase
{
    private readonly IUnitsService _unitsService;

    private string _unitName;

    /// <summary>
    /// Модель данных. Имя
    /// </summary>
    public string UnitName
    {
        get => _unitName;
        set
        {
            _unitName = value;
            OnPropertyChanged();
        }
    }

    public UnitViewModel(IUnitsService unitsService, int? currentId) : base(currentId)
    {
        _unitsService = unitsService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    /// <summary>
    /// Обработка команды нажатия кнопки сохранения данных
    /// </summary>
    /// <param name="sender"></param>
    public void Enter(object sender)
    {
        if (string.IsNullOrWhiteSpace(_unitName))
        {
            MessageBox.Show("Введите название единицы измерения!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        bool result = CurrentId.HasValue ? Update() : Create();

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    /// <summary>
    ///  Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update()
    {
        var unit = new Units
        {
            Id = CurrentId.Value,
            UnitName = _unitName
        };

        try
        {
            _unitsService.Update(unit);
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
    private bool Create()
    {
        var unit = new Units
        {
            UnitName = _unitName
        };

        int id = _unitsService.Create(unit);

        if (id == 0)
        {
            MessageBox.Show("Такая единица измерения уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            Units? unit = _unitsService.Get(CurrentId.Value);

            if (unit == null)
            {
                MessageBox.Show("Такой единицы измерения не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            UnitName = unit.UnitName;

            return true;
        }

        return true;
    }
}