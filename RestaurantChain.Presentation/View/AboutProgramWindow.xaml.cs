using System.Windows;

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
            Text.Text =
                "Курсовая работа по дисциплине 'Базы данных'\n" +
                "Выполнил:\n" +
                "Студент: Хусаинов Артур Мансурович\n" +
                "Группа: АВТ-213\n" +
                "Данная программа является программой для работы с базой данных\n" +
                "Сеть ресторанов\n" +
                "Лицензия: беспралтная программа для некомерческого пользования.";
        }
    }
}
