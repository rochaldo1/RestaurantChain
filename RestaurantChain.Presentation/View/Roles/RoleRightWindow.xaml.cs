using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.RoleRights;

namespace RestaurantChain.Presentation.View.Roles;

public partial class RoleRightWindow : UserControl
{
    /// <summary>
    ///     Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public RoleRightWindow(IServiceProvider serviceProvider, int? entityId, int roleId)
    {
        InitializeComponent();
        var roleService = serviceProvider.GetRequiredService<IRolesService>();
        var menuService = serviceProvider.GetRequiredService<IMenuService>();
        DataContext = new RoleRightsViewModel(roleService, menuService, entityId, roleId);

        if (DataContext is RoleRightsViewModel vm)
        {
            vm.OnSaveSuccess += SaveSuccess;
            vm.OnCancel += SaveError;
        }

        PreviewKeyDown += PreviewKeyDownHandle;
    }

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        ((Window)Parent).Close();
    }

    public void SaveSuccess()
    {
        IsSuccess = true;
        ((Window)Parent).Close();
    }

    public void SaveError()
    {
        IsSuccess = false;
        ((Window)Parent).Close();
    }

    private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                ((Window)Parent).Close();

                break;
        }
    }
}