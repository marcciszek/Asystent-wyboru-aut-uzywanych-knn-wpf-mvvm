using System;
using System.Collections.Generic;
using System.Security;
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

namespace Asystent_wyboru_aut_uzywanych.View
{
    /// <summary>
    /// Logika interakcji dla klasy ManagerLoginViewControl.xaml
    /// </summary>
    public partial class ManagerLoginViewControl : UserControl
    {
        public ManagerLoginViewControl()
        {
            InitializeComponent();
        }

        //=========================================================================
        public string UserLogin
        {
            get { return (string)GetValue(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }

        public static readonly DependencyProperty UserLoginProperty =
            DependencyProperty.Register(
                nameof(UserLogin),
                typeof(string),
                typeof(ManagerLoginViewControl));
        //=========================================================================
        //public SecureString UserPassword
        //{
        //    get { return (SecureString)GetValue(UserPasswordProperty); }
        //    set { SetValue(UserPasswordProperty, value); }
        //}

        //public static readonly DependencyProperty UserPasswordProperty =
        //    DependencyProperty.Register(
        //        nameof(UserLogin),
        //        typeof(SecureString),
        //        typeof(ManagerLoginViewControl));
        ////=========================================================================


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).removeVM.SecurePassword = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
