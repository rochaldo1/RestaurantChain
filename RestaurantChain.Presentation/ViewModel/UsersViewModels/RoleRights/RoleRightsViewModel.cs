using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.RoleRights;

internal sealed class RoleRightsViewModel : EditViewModelBase
{
    private readonly IRolesService _rolesService;
    private bool _w;
    private bool _r;
    private bool _e;
    private bool _d;
    private int _selectedMenuId;
    private readonly int _selectedRoleId;
    private IReadOnlyCollection<Menu> _menuDataSource;

    /// <summary>
    /// Модель данных. Выбранное меню
    /// </summary>
    public int SelectedMenuId
    {
        get => _selectedMenuId;
        set
        {
            _selectedMenuId = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Список меню
    /// </summary>
    public IReadOnlyCollection<Menu> MenuDataSource
    {
        get => _menuDataSource;
        set
        {
            _menuDataSource = value;
            OnPropertyChanged();
        }
    }
    
    /// <summary>
    /// Модель данных. Права на запись
    /// </summary>
    public bool W
    {
        get => _w;
        set
        {
            _w = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Права на чтение
    /// </summary>
    public bool R
    {
        get => _r;
        set
        {
            _r = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Права на редактирование
    /// </summary>
    public bool E
    {
        get => _e;
        set
        {
            _e = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Права на удаление
    /// </summary>
    public bool D
    {
        get => _d;
        set
        {
            _d = value;
            OnPropertyChanged();
        }
    }

    public RoleRightsViewModel(IRolesService rolesService, IMenuService menuService, int? currentId, int roleId) : base(currentId)
    {
        _selectedRoleId = roleId;
        MenuDataSource = menuService.List();
        _rolesService = rolesService;

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
        RolesRights? rolesRights = ValidateAndGet();

        if (rolesRights == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(rolesRights) : Create(rolesRights);

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }
    
    /// <summary>
    /// Валидация данных и вернуть модель
    /// </summary>
    /// <returns></returns>
    private RolesRights ValidateAndGet()
    {
        if (SelectedMenuId <= 0)
        {
            MessageBox.Show("Не выбрано меню", "Редактирование прав", MessageBoxButton.OK, MessageBoxImage.Warning);

            return null;
        }

        return new RolesRights
        {
            D = D,
            E = E,
            W = W,
            R = R,
            MenuId = SelectedMenuId,
            RoleId = _selectedRoleId,
            Id = CurrentId ?? 0
        };
    }

    /// <summary>
    ///  Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create(RolesRights rolesRights)
    {
        _rolesService.CreateRight(rolesRights);

        return true;
    }

    /// <summary>
    ///     Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update(RolesRights rolesRights)
    {
        _rolesService.UpdateRight(rolesRights);

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
            RolesRights rolesRights = _rolesService.GetRight(CurrentId.Value);

            W = rolesRights.W;
            E = rolesRights.E;
            D = rolesRights.D;
            R = rolesRights.R;
            _selectedMenuId = rolesRights.MenuId;
        }

        return true;
    }
}