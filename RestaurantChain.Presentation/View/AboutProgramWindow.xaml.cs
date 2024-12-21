using System.Windows;
using System.Windows.Input;

using RestaurantChain.Presentation.ViewModel.UnitsViewModel;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для AboutProgramWindow.xaml
    /// </summary>
    public partial class AboutProgramWindow : Window
    {
        public AboutProgramWindow()
        {
            InitializeComponent();
            PreviewKeyDown += PreviewKeyDownHandle;
            Text.Text =
                "Курсовая работа по дисциплине 'Базы данных'\n" +
                "Выполнил:\n" +
                "Студент: Хусаинов Артур Мансурович\n" +
                "Группа: АВТ-213\n" +
                "Данная программа является программой для работы с базой данных\n" +
                "Сеть ресторанов\n" +
                "Лицензия: бесплатная программа для некомерческого пользования.";
        }
        private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    ((Window)Parent).Close();

                    break;
            }
        }
    }
}
