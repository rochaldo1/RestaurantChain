using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace RestaurantChain.Presentation.View.RestaurantsViews;

/// <summary>
/// Логика взаимодействия для RestaurantWindow.xaml
/// </summary>
public partial class RestaurantWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public RestaurantWindow(IServiceProvider serviceProvider, int? restaurantId)
    {
        var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();
        var streetsService = serviceProvider.GetRequiredService<IStreetsService>();
        InitializeComponent();
        DataContext = new RestaurantViewModel(restaurantsService, streetsService, restaurantId);

        if (DataContext is RestaurantViewModel vw)
        {
            vw.OnSaveSuccess += SaveSuccess;
            vw.OnCancel += SaveError;
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