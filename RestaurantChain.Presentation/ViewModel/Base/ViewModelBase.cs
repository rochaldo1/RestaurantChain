using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.Classes;

namespace RestaurantChain.Presentation.ViewModel.Base;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    private readonly string _dllName;

    public Visibility HasW
    {
        get
        {
            UserRoleRight? menu = GetByAction(CurrentState.Menu);

            return menu == null || menu.W ? Visibility.Visible : Visibility.Hidden;
        }
    }

    public Visibility HasE
    {
        get
        {
            UserRoleRight? menu = GetByAction(CurrentState.Menu);

            return menu == null || menu.E ? Visibility.Visible : Visibility.Hidden;
        }
    }

    public Visibility HasD
    {
        get
        {
            UserRoleRight? menu = GetByAction(CurrentState.Menu);

            return menu == null || menu.D ? Visibility.Visible : Visibility.Hidden;
        }
    }

    protected ViewModelBase()
    {
        _dllName = GetType().Name;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private UserRoleRight GetByAction(IReadOnlyCollection<UserRoleRight> items)
    {
        foreach (UserRoleRight item in items)
        {
            if (string.Equals(item.DllName, _dllName, StringComparison.InvariantCultureIgnoreCase))
            {
                return item;
            }

            UserRoleRight? menu = GetByAction(item.Childrens);

            if (menu != null)
            {
                return menu;
            }
        }

        return null;
    }
}