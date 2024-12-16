﻿using System;
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
using System.Windows.Shapes;

namespace RestaurantChainWPF.View
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
