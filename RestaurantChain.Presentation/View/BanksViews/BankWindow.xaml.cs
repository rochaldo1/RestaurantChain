using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.BanksViewModel;

namespace RestaurantChain.Presentation.View.BanksViews;

/// <summary>
///     Логика взаимодействия для BankWindow.xaml
/// </summary>
public partial class BankWindow : UserControl
{
    /// <summary>
    ///     Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public BankWindow(IServiceProvider serviceProvider, int? bankId)
    {
        var banksService = serviceProvider.GetRequiredService<IBanksService>();
        InitializeComponent();
        DataContext = new BankViewModel(banksService, bankId);

        if (DataContext is BankViewModel bankViewModel)
        {
            bankViewModel.OnSaveSuccess += SaveSuccess;
            bankViewModel.OnCancel += SaveError;
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
                btnOk.Command.Execute(null);

                break;
        }
    }

    private void BtnOk_OnClick(object sender, RoutedEventArgs e)
    {
        (DataContext as BankViewModel).EnterCommand.Execute(sender);
    }
}