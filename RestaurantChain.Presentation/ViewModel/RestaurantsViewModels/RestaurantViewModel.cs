using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;

internal class RestaurantViewModel : EditViewModelBase
{
    private readonly IRestaurantsService _restaurantsService;
    private readonly IStreetsService _streetsService;

    private string _restaurantName;
    private IReadOnlyCollection<Streets> _streetsList;
    private int _selectedStreetId;
    private string _phoneNumber;
    private string _directorName;
    private string _directorLastName;
    private string _directorSurname;

    public string RestaurantName
    {
        get => _restaurantName;
        set
        {
            _restaurantName = value;
            OnPropertyChanged();
        }
    }

    public IReadOnlyCollection<Streets> StreetsList
    {
        get => _streetsList;
        set
        {
            _streetsList = value;
            OnPropertyChanged();
        }
    }

    public int SelectedStreetId
    {
        get => _selectedStreetId;
        set
        {
            _selectedStreetId = value;
            OnPropertyChanged();
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged();
        }
    }

    public string DirectorName
    {
        get => _directorName;
        set
        {
            _directorName = value;
            OnPropertyChanged();
        }
    }

    public string DirectorLastName
    {
        get => _directorLastName;
        set
        {
            _directorLastName = value;
            OnPropertyChanged();
        }
    }

    public string DirectorSurname
    {
        get => _directorSurname;
        set
        {
            _directorSurname = value;
            OnPropertyChanged();
        }
    }

    public RestaurantViewModel(IRestaurantsService restaurantsService, IStreetsService streetsService, int? currentId) : base(currentId)
    {
        _restaurantsService = restaurantsService;
        _streetsService = streetsService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    private void Enter(object sender)
    {
        Restaurants restaurant = ValidateAndGetModelOnSave();

        if (restaurant == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(restaurant) : Create(restaurant);

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(Restaurants restaurant)
    {
        try
        {
            _restaurantsService.Update(restaurant);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private bool Create(Restaurants restaurant)
    {
        int id = _restaurantsService.Create(restaurant);

        if (id == 0)
        {
            MessageBox.Show("Такой ресторан уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    private Restaurants ValidateAndGetModelOnSave()
    {
        var restaurant = new Restaurants
        {
            Id = CurrentId ?? 0,
            RestaurantName = _restaurantName,
            StreetId = _selectedStreetId,
            PhoneNumber = _phoneNumber,
            DirectorName = _directorName,
            DirectorLastName = _directorLastName,
            DirectorSurname= _directorSurname
        };

        var errors = new List<string>();

        if (string.IsNullOrEmpty(restaurant.RestaurantName))
        {
            errors.Add("Название ресторана");
        }

        if (string.IsNullOrEmpty(restaurant.PhoneNumber))
        {
            errors.Add("Номер телефона");
        }

        if (string.IsNullOrEmpty(restaurant.DirectorName))
        {
            errors.Add("Имя директора");
        }

        if (string.IsNullOrEmpty(restaurant.DirectorLastName))
        {
            errors.Add("Фамилия директора");
        }

        if (string.IsNullOrEmpty(restaurant.DirectorSurname))
        {
            errors.Add("Отчество директора");
        }

        if (restaurant.StreetId <= 0)
        {
            errors.Add("Улица");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (restaurant.PhoneNumber.Length < 11)
        {
            MessageBox.Show("Телефон не может быть меньше 11 цифр", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return restaurant;
    }

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            Restaurants? restaurant = _restaurantsService.Get(CurrentId.Value);

            if (restaurant == null)
            {
                MessageBox.Show("Такого ресторана не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            RestaurantName = restaurant.RestaurantName;
            StreetsList = _streetsService.List();
            SelectedStreetId = StreetsList.First(x => x.Id == restaurant.StreetId).Id;
            DirectorName = restaurant.DirectorName;
            DirectorLastName = restaurant.DirectorLastName;
            DirectorSurname = restaurant.DirectorSurname;
            PhoneNumber = restaurant.PhoneNumber;

            return true;
        }

        StreetsList = _streetsService.List();

        return true;
    }
}