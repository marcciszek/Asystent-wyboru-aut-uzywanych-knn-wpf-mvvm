using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Asystent_wyboru_aut_uzywanych.View
{
    using ViewModel;
    /// <summary>
    /// Logika interakcji dla klasy PredictHistoryDetailsPage.xaml
    /// </summary>
    public partial class PredictHistoryDetailsPage : Window
    {
        internal PredictHistoryDetailsPage(MainViewModel mainVM)
        {
            this.DataContext = mainVM;
            InitializeComponent();
        }
    }
}
