using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.UnitsViewModel;

namespace RestaurantChain.Presentation.View.UnitsViews;

/// <summary>
///     Логика взаимодействия для UnitWindow.xaml
/// </summary>
public partial class UnitWindow : UserControl
{
    /// <summary>
    ///     Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public UnitWindow(IServiceProvider serviceProvider, int? unitId)
    {
        var unitsService = serviceProvider.GetRequiredService<IUnitsService>();
        InitializeComponent();
        DataContext = new UnitViewModel(unitsService, unitId);

        if (DataContext is UnitViewModel unitViewModel)
        {
            unitViewModel.OnSaveSuccess += SaveSuccess;
            unitViewModel.OnCancel += SaveError;
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