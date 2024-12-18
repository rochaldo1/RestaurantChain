using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.UnitsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantChain.Presentation.View.UnitsViews
{
    /// <summary>
    /// Логика взаимодействия для UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
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
