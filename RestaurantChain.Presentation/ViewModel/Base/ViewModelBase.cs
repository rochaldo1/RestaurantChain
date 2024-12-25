using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.Classes;

namespace RestaurantChain.Presentation.ViewModel.Base;

/// <summary>
/// Базовый класс для всех ViewModels
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Имя модуля, чтоб проверять его в таблице прав
    /// </summary>
    private readonly string _dllName;

    /// <summary>
    /// Можно ли создавать запись
    /// </summary>
    public Visibility HasW
    {
        get
        {
            UserRoleRight? menu = GetByAction(CurrentState.Menu);

            return menu == null || menu.W ? Visibility.Visible : Visibility.Hidden;
        }
    }

    /// <summary>
    /// Можно ли редактировать запись
    /// </summary>
    public Visibility HasE
    {
        get
        {
            UserRoleRight? menu = GetByAction(CurrentState.Menu);

            return menu == null || menu.E ? Visibility.Visible : Visibility.Hidden;
        }
    }

    /// <summary>
    /// Можгно ли удалять запись
    /// </summary>
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

    /// <summary>
    /// Поиск прав ркурсивно в меню по имени текущего модуля DLL
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    private UserRoleRight GetByAction(IReadOnlyCollection<UserRoleRight> items)
    {
        foreach (UserRoleRight item in items)
        {
            //если нашли совпадение по модулю, то вернуть это меню
            if (string.Equals(item.DllName, _dllName, StringComparison.InvariantCultureIgnoreCase))
            {
                return item;
            }

            //поискать в дочерних
            UserRoleRight? menu = GetByAction(item.Childrens);

            //Если в дочерних нашли то тоже вернуть
            if (menu != null)
            {
                return menu;
            }
        }

        //ничего не нашли
        return null;
    }
}