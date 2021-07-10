using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string StatusText
        {
            get { return (string)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register(
                nameof(StatusText),
                typeof(string),
                typeof(ProgramStatusViewControl));
        //=========================================================================
        public uint StatusLevel
        {
            get { return (uint)GetValue(StatusLevelProperty); }
            set { SetValue(StatusLevelProperty, value); }
        }

        public static readonly DependencyProperty StatusLevelProperty =
            DependencyProperty.Register(
                nameof(StatusLevel),
                typeof(uint),
                typeof(ProgramStatusViewControl));
        //=========================================================================
        private string EllipseColor
        {
            get { return (string)GetValue(EllipseColorProperty); }
            set { SetValue(EllipseColorProperty, value); }
        }
        public static readonly DependencyProperty EllipseColorProperty =
            DependencyProperty.Register(
                nameof(EllipseColor),
                typeof(string),
                typeof(ProgramStatusViewControl),
                new PropertyMetadata("Green"));
        //=========================================================================
        private void TextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (StatusLevel == 0)
                EllipseColor = "Green";
            if (StatusLevel == 1)
                EllipseColor = "Yellow";
            if (StatusLevel == 2)
                EllipseColor = "Red";
            if (StatusLevel >= 3)
                EllipseColor = "Black";
        }
        //=========================================================================


    }
}
