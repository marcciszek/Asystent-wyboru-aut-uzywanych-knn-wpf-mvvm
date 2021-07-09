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
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        internal LoginPage(RemoveViewModel removeVM)
        {
            this.DataContext = removeVM;
            InitializeComponent();
        }
    }
}
