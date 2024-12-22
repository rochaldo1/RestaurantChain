using System.Windows;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void AboutProgram_Click(object sender, RoutedEventArgs e)
    {
        AboutProgramWindow aboutProgramWindow = new();
        aboutProgramWindow.ShowDialog();
    }

    private void ChangePassword_Click(object sender, RoutedEventArgs e)
    {
        ChangePasswordWindow changePasswordWindow = new(_serviceProvider);
        changePasswordWindow.ShowDialog();
    }

    private void Settings_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Streets_Click(object sender, RoutedEventArgs e)
    {
        var view = new StreetsViews.StreetsListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void GroupsOfDishes_Click(object sender, RoutedEventArgs e)
    {
        var view = new GroupsOfDishesViews.GroupsOfDishesListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Banks_Click(object sender, RoutedEventArgs e)
    {
        var view = new BanksViews.BanksListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Units_Click(object sender, RoutedEventArgs e)
    {
        var view = new UnitsViews.UnitsListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Content_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Suppliers_Click(object sender, RoutedEventArgs e)
    {
        var view = new SuppliersViews.SuppliersListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Products_Click(object sender, RoutedEventArgs e)
    {
        var view = new ProductsViews.ProductsListWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Dishes_Click(object sender, RoutedEventArgs e)
    {
        //var view = new DishesViews.DishesListWindow(_serviceProvider);
        //mainView.Content = view;
    }

    private void Queries_OnClick(object sender, RoutedEventArgs e)
    {
        var view = new QueriesWindow(_serviceProvider);
        mainView.Content = view;
    }

    private void Supplies_OnClick(object sender, RoutedEventArgs e)
    {
        var view = new SuppliesViews.SuppliesWindow(_serviceProvider);
        mainView.Content = view;
    }
}