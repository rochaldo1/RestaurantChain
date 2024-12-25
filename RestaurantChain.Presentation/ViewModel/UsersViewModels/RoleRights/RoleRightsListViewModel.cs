using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.Roles;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.RoleRights;

internal sealed class RoleRightsListViewModel : ListViewModelBase<RolesRightsView>
{
    private readonly IRolesService _rolesService;

    private IReadOnlyCollection<Domain.Models.Roles> _rolesDataSource;

    private int _selectedRoleId;

    /// <summary>
    /// Модель данных. Список ролей
    /// </summary>
    public IReadOnlyCollection<Domain.Models.Roles> RolesDataSource
    {
        get => _rolesDataSource;
        set
        {
            _rolesDataSource = value;
            OnPropertyChanged();
            DataBind();
        }
    }

    /// <summary>
    /// Модель данных. Выбранная роль
    /// </summary>
    public int SelectedRoleId
    {
        get => _selectedRoleId;
        set
        {
            _selectedRoleId = value;
            OnPropertyChanged();
            DataBind();
        }
    }

    public RoleRightsListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _rolesService = serviceProvider.GetRequiredService<IRolesService>();
        DataBind();
        RolesDataSource = _rolesService.List();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<RolesRightsView> entities = _rolesService.ListRights(SelectedRoleId);
        SetEntities(entities);
    }
    
    /// <summary>
    /// Установить команды CRUD кнопкам
    /// </summary>
    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    /// <summary>
    /// Вызов команды создания записи из окна таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void CreateEntity(object sender)
    {
        var view = new RoleRightWindow(ServiceProvider, entityId: null, SelectedRoleId);
        WindowHelper.ShowDialog(view, "Создание записи", width: 400, height: 400);
        DataBind();
    }

    /// <summary>
    /// Вызов команды редактирования выбранной записи из таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new RoleRightWindow(ServiceProvider, SelectedItem.Id, SelectedRoleId);
        WindowHelper.ShowDialog(view, "Редактирование записи", width: 400, height: 400);
        DataBind();
    }

    /// <summary>
    /// Вызов команды удаления записи
    /// </summary>
    /// <param name="sender"></param>
    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _rolesService.DeleteRight(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}