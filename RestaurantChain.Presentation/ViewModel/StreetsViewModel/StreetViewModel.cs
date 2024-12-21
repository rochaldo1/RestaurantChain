using System.ComponentModel;
using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.StreetsViewModel;

internal class StreetViewModel : EditViewModelBase
{
    private readonly IStreetsService _streetsService;

    private string _streetName;

    public string StreetName
    {
        get => _streetName;
        set
        {
            _streetName = value;
            OnPropertyChanged();
        }
    }

    public StreetViewModel(IStreetsService streetsService, int? currentId) : base(currentId)
    {
        _streetsService = streetsService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public void Enter(object sender)
    {
        if (string.IsNullOrWhiteSpace(_streetName))
        {
            MessageBox.Show("Введите название улицы!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        // Сохранить или обновить.
        bool result = CurrentId.HasValue ? Update() : Create();

        if (result) // Если успех - закрыть окно.
        {
            OnSaveSuccess?.Invoke();
        }
    }

    /// <summary>
    /// Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update()
    {
        var street = new Streets
        {
            Id = CurrentId.Value,
            StreetName = _streetName
        };

        try
        {
            _streetsService.Update(street);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create()
    {
        var street = new Streets
        {
            StreetName = _streetName
        };

        int id = _streetsService.Create(street);

        if (id == 0)
        {
            MessageBox.Show("Такая улица уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            Streets? street = _streetsService.Get(CurrentId.Value);

            if (street == null)
            {
                MessageBox.Show("Такой улицы не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            StreetName = street.StreetName;

            return true;
        }

        return true;
    }
}