using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.Roles;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.Roles;

internal sealed class RolesListViewModel : ListViewModelBase<Domain.Models.Roles>
{
    private readonly IRolesService _rolesService;

    public RolesListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _rolesService = serviceProvider.GetRequiredService<IRolesService>();
        DataBind();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<Domain.Models.Roles> entities = _rolesService.List();
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
        var view = new RoleWindow(ServiceProvider, entityId: null);
        WindowHelper.ShowDialog(view, "Создание записи");
        DataBind();
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new RoleWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи");
        DataBind();
    }

    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show($"Удалить роль '{SelectedItem.Name}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            try
            {
                _rolesService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }
        }
        else
        {
            return;
        }

        DataBind();
    }
}