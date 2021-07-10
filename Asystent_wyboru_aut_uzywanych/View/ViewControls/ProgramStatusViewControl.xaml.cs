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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asystent_wyboru_aut_uzywanych.View.ViewControls
{
    /// <summary>
    /// Logika interakcji dla klasy ProgramStatusViewControl.xaml
    /// </summary>
    public partial class ProgramStatusViewControl : UserControl
    {
        public ProgramStatusViewControl()
        {
            InitializeComponent();
        }
        //=========================================================================
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
                nameof(Status),
                typeof(string),
                typeof(ProgramStatusViewControl));
        //=========================================================================
    }
}
