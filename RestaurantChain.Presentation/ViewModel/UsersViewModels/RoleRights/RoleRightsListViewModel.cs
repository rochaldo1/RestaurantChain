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

    protected override void DataBind()
    {
        IReadOnlyCollection<RolesRightsView> entities = _rolesService.ListRights(SelectedRoleId);
        SetEntities(entities);
    }

    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    private void CreateEntity(object sender)
    {
        var view = new RoleRightWindow(ServiceProvider, entityId: null, SelectedRoleId);
        WindowHelper.ShowDialog(view, "Создание записи", width: 400, height: 400);
        DataBind();
    }

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