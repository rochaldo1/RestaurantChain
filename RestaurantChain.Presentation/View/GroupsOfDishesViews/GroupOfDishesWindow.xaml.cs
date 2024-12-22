using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace RestaurantChain.Presentation.View.GroupsOfDishesViews;

/// <summary>
/// Логика взаимодействия для GroupOfDishesWindow.xaml
/// </summary>
public partial class GroupOfDishesWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public GroupOfDishesWindow(IServiceProvider serviceProvider, int? groupId)
    {
        var groupsOfDishesService = serviceProvider.GetRequiredService<IGroupsOfDishesService>();
        InitializeComponent();
        DataContext = new GroupOfDishesViewModel(groupsOfDishesService, groupId);
        if (DataContext is GroupOfDishesViewModel groupOfDishesViewModel)
        {
            groupOfDishesViewModel.OnSaveSuccess += SaveSuccess;
            groupOfDishesViewModel.OnCancel += SaveError;
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
            case Key.Enter:
                btnOk.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

                break;
        }
    }
}