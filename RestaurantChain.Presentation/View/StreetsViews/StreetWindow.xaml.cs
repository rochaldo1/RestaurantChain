using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.StreetsViewModel;

namespace RestaurantChain.Presentation.View.StreetsViews
{
    /// <summary>
    /// Логика взаимодействия для StreetWindow.xaml
    /// </summary>
    public partial class StreetWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public StreetWindow(IServiceProvider serviceProvider, int? streetId)
        {
            var streetsService = serviceProvider.GetRequiredService<IStreetsService>();
            InitializeComponent();
            DataContext = new StreetViewModel(streetsService, streetId);
            if (DataContext is StreetViewModel streetViewModel)
            {
                streetViewModel.OnSaveSuccess += SaveSuccess;
                streetViewModel.OnCancel += SaveError;
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
}
