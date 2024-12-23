using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.AvailibilityInRestaurantViewModel;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;

public partial class NomenclatureWindow : UserControl
{
    /// <summary>
    /// ��������� ���������� ������.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public NomenclatureWindow(IServiceProvider serviceProvider, int restaurantId, int? nomenclatureId)
    {
        var nomenclatureService = serviceProvider.GetRequiredService<INomenclatureService>();

        InitializeComponent();
        DataContext = new NomenclatureViewModel(serviceProvider, restaurantId, nomenclatureId);
        if (DataContext is NomenclatureViewModel vm)
        {
            vm.OnSaveSuccess += SaveSuccess;
            vm.OnCancel += SaveError;
        }
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