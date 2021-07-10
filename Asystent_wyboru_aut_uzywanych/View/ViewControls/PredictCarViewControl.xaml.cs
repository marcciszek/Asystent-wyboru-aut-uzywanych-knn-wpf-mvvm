using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy PredictCarViewControl.xaml
    /// </summary>
    public partial class PredictCarViewControl : UserControl
    {
        public PredictCarViewControl()
        {
            InitializeComponent();
        }
        #region DependencyProperty 
        //=========================================================================

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(
                nameof(Type),
                typeof(string),
                typeof(PredictCarViewControl));
        //-------------------------------------------------------------------------
        public string[] AvailableTypes
        {
            get { return (string[])GetValue(AvailableTypesProperty); }
            set { SetValue(AvailableTypesProperty, value); }
        }

        public static readonly DependencyProperty AvailableTypesProperty =
            DependencyProperty.Register(
                nameof(AvailableTypes),
                typeof(string[]),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string Gear
        {
            get { return (string)GetValue(GearProperty); }
            set { SetValue(GearProperty, value); }
        }

        public static readonly DependencyProperty GearProperty =
            DependencyProperty.Register(
                nameof(Gear),
                typeof(string),
                typeof(PredictCarViewControl));
        //-------------------------------------------------------------------------
        public string[] AvailableGears
        {
            get { return (string[])GetValue(AvailableGearsProperty); }
            set { SetValue(AvailableGearsProperty, value); }
        }

        public static readonly DependencyProperty AvailableGearsProperty =
            DependencyProperty.Register(
                nameof(AvailableGears),
                typeof(string[]),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string Fuel
        {
            get { return (string)GetValue(FuelProperty); }
            set { SetValue(FuelProperty, value); }
        }

        public static readonly DependencyProperty FuelProperty =
            DependencyProperty.Register(
                nameof(Fuel),
                typeof(string),
                typeof(PredictCarViewControl));
        //-------------------------------------------------------------------------
        public string[] AvailableFuels
        {
            get { return (string[])GetValue(AvailableFuelsProperty); }
            set { SetValue(AvailableFuelsProperty, value); }
        }

        public static readonly DependencyProperty AvailableFuelsProperty =
            DependencyProperty.Register(
                nameof(AvailableFuels),
                typeof(string[]),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string Damage
        {
            get { return (string)GetValue(DamageProperty); }
            set { SetValue(DamageProperty, value); }
        }

        public static readonly DependencyProperty DamageProperty =
            DependencyProperty.Register(
                nameof(Damage),
                typeof(string),
                typeof(PredictCarViewControl));
        //-------------------------------------------------------------------------
        public string[] AvailableDamages
        {
            get { return (string[])GetValue(AvailableDamagesProperty); }
            set { SetValue(AvailableDamagesProperty, value); }
        }

        public static readonly DependencyProperty AvailableDamagesProperty =
            DependencyProperty.Register(
                nameof(AvailableDamages),
                typeof(string[]),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string PriceMin
        {
            get { return (string)GetValue(PriceMinProperty); }
            set { SetValue(PriceMinProperty, value); }
        }

        public static readonly DependencyProperty PriceMinProperty =
            DependencyProperty.Register(
                nameof(PriceMin),
                typeof(string),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string PriceMax
        {
            get { return (string)GetValue(PriceMaxProperty); }
            set { SetValue(PriceMaxProperty, value); }
        }

        public static readonly DependencyProperty PriceMaxProperty =
            DependencyProperty.Register(
                nameof(PriceMax),
                typeof(string),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string Power
        {
            get { return (string)GetValue(PowerProperty); }
            set { SetValue(PowerProperty, value); }
        }

        public static readonly DependencyProperty PowerProperty =
            DependencyProperty.Register(
                nameof(Power),
                typeof(string),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string Mileage
        {
            get { return (string)GetValue(MileageProperty); }
            set { SetValue(MileageProperty, value); }
        }

        public static readonly DependencyProperty MileageProperty =
            DependencyProperty.Register(
                nameof(Mileage),
                typeof(string),
                typeof(PredictCarViewControl));
        //=========================================================================
        public string CarYear
        {
            get { return (string)GetValue(CarYearProperty); }
            set { SetValue(CarYearProperty, value); }
        }

        public static readonly DependencyProperty CarYearProperty =
            DependencyProperty.Register(
                nameof(CarYear),
                typeof(string),
                typeof(PredictCarViewControl));
        //=========================================================================
        #endregion

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void SpacePreventTextBox(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
