using System.Windows;
using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;

public partial class NomenclatureWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public NomenclatureWindow(IServiceProvider serviceProvider, int restaurantId, int? nomenclatureId)
    {
        InitializeComponent();
        DataContext = new NomenclatureViewModel(serviceProvider, restaurantId, nomenclatureId);
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
}