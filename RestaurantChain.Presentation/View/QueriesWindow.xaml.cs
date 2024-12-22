using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Interaction logic for QueriesWindow.xaml
/// </summary>
public partial class QueriesWindow : UserControl
{
    public QueriesWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        var queryService = serviceProvider.GetRequiredService<IQueryService>();
        DataContext = new QueriesViewModel(queryService);
    }
}