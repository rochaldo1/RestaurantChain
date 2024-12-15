using RestaurantChain.Storage;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantChainWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainWindow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = _unitOfWork.UsersRepository.Get(1);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}