using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Interaction logic for QueriesWindow.xaml
/// </summary>
public partial class QueriesWindow : UserControl
{
    public QueriesWindow(IServiceProvider serviceProvider, string sql)
    {
        InitializeComponent();
        DataContext = new QueriesViewModel(serviceProvider, sql, this);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Разное - Запросы";
    }
}