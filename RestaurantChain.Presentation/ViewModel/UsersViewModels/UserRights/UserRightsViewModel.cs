using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.UserRights;

internal class UserRightsViewModel : EditViewModelBase
{
    private readonly IUsersService _usersService;

    private bool _w;
    private bool _r;
    private bool _e;
    private bool _d;

    public bool W
    {
        get => _w;
        set
        {
            _w = value;
            OnPropertyChanged();
        }
    }

    public bool R
    {
        get => _r;
        set
        {
            _r = value;
            OnPropertyChanged();
        }
    }

    public bool E
    {
        get => _e;
        set
        {
            _e = value;
            OnPropertyChanged();
        }
    }

    public bool D
    {
        get => _d;
        set
        {
            _d = value;
            OnPropertyChanged();
        }
    }

    public UserRightsViewModel(IUsersService usersService, int? currentId) : base(currentId)
    {
        _usersService = usersService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public void Enter(object sender)
    {
        if (Update()) // Если успех - закрыть окно.
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
        var userRights = _usersService.GetUserRights(CurrentId.Value);
        userRights.R = R;
        userRights.E = E;
        userRights.D = D;
        userRights.W = W;

        _usersService.UpdateUserRights(userRights);

        return true;
    }

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            var userRights = _usersService.GetUserRights(CurrentId.Value);

            W = userRights.W;
            E = userRights.E;
            D = userRights.D;
            R = userRights.R;
        }

        return true;
    }
}