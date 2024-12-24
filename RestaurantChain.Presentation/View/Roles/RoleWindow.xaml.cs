using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.Roles;

namespace RestaurantChain.Presentation.View.Roles;

public partial class RoleWindow : UserControl
{
    /// <summary>
    ///     Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public RoleWindow(IServiceProvider serviceProvider, int? entityId)
    {
        InitializeComponent();
        var roleService = serviceProvider.GetRequiredService<IRolesService>();
        DataContext = new RoleViewModel(roleService, entityId);

        if (DataContext is RoleViewModel vm)
        {
            vm.OnSaveSuccess += SaveSuccess;
            vm.OnCancel += SaveError;
        }

        PreviewKeyDown += PreviewKeyDownHandle;
        Loaded += (sender, args) => { txtBox.Focus(); };
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