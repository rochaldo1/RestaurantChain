using System.Windows.Controls;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;

public partial class NomenclatureListWindow : UserControl
{
    public NomenclatureListWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        InitializeComponent();
        DataContext = new NomenclatureListViewModel(serviceProvider, restaurantId);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Рестораны - Номенклатура";
    }
}