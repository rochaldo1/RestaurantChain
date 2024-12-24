using System.Windows;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.Roles;

internal sealed class RoleViewModel : EditViewModelBase
{
    private readonly IRolesService _rolesService;
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public RoleViewModel(IRolesService rolesService, int? currentId) : base(currentId)
    {
        _rolesService = rolesService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public void Enter(object sender)
    {
        Domain.Models.Roles? role = ValidateAndGet();

        if (role == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(role) : Create(role);

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private Domain.Models.Roles ValidateAndGet()
    {
        if (string.IsNullOrEmpty(Name))
        {
            MessageBox.Show("Введите имя", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);

            return null;
        }

        return new Domain.Models.Roles
        {
            Id = CurrentId ?? 0,
            Name = Name
        };
    }

    private bool Create(Domain.Models.Roles roles)
    {
        _rolesService.Create(roles);

        return true;
    }

    /// <summary>
    ///     Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update(Domain.Models.Roles roles)
    {
        _rolesService.Update(roles);

        return true;
    }

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            Domain.Models.Roles role = _rolesService.Get(CurrentId.Value);

            Name = role.Name;
        }

        return true;
    }
}