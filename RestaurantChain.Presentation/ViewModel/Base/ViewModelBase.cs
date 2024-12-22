using RestaurantChain.Presentation.Classes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.Presentation.ViewModel.Base;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ViewModelBase()
    {
        _dllName = GetType().Name;
    }

    public Visibility HasW
    {
        get
        {
            var menu = GetByAction(CurrentState.Menu);
            return (menu == null || menu.W) ? Visibility.Visible : Visibility.Hidden;
        }
    }

    public Visibility HasE
    {
        get
        {
            var menu = GetByAction(CurrentState.Menu);
            return (menu == null || menu.E) ? Visibility.Visible : Visibility.Hidden;
        }
    }

    public Visibility HasD
    {
        get
        {
            var menu = GetByAction(CurrentState.Menu);
            return (menu == null || menu.D) ? Visibility.Visible : Visibility.Hidden;
        }
    }

    private readonly string _dllName;

    private Menu GetByAction(IReadOnlyCollection<Menu> items)
    {
        foreach (var item in items)
        {
            if (string.Equals(item.DLLName, _dllName, StringComparison.InvariantCultureIgnoreCase))
            {
                return item;
            }

            var menu = GetByAction(item.Childrens);
            if (menu != null)
            {
                return menu;
            }
        }

        return null;
    }
}