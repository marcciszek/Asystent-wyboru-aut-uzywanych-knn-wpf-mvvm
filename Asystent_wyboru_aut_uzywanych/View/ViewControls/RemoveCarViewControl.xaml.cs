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
    using DAL.Encje;
    /// <summary>
    /// Logika interakcji dla klasy RemoveCarViewControl.xaml
    /// </summary>
    public partial class RemoveCarViewControl : UserControl
    {
        public RemoveCarViewControl()
        {
            InitializeComponent();
        }

        #region DependencyProperty
        //=========================================================================
        public string Brand
        {
            get { return (string)GetValue(BrandProperty); }
            set { SetValue(BrandProperty, value); }
        }

        public static readonly DependencyProperty BrandProperty =
            DependencyProperty.Register(
                nameof(Brand),
                typeof(string),
                typeof(RemoveCarViewControl));
        //------------------------------------------------------------------------
        public string[] AvailableBrands
        {
            get { return (string[])GetValue(AvailableBrandsProperty); }
            set { SetValue(AvailableBrandsProperty, value); }
        }

        public static readonly DependencyProperty AvailableBrandsProperty =
            DependencyProperty.Register(
                nameof(AvailableBrands),
                typeof(string[]),
                typeof(RemoveCarViewControl));
        //=========================================================================
        public string Model
        {
            get { return (string)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register(
                nameof(Model),
                typeof(string),
                typeof(RemoveCarViewControl));
        //-------------------------------------------------------------------------
        public ObservableCollection<string> AvailableModels
        {
            get { return (ObservableCollection<string>)GetValue(AvailableModelsProperty); }
            set { SetValue(AvailableModelsProperty, value); }
        }

        public static readonly DependencyProperty AvailableModelsProperty =
            DependencyProperty.Register(
                nameof(AvailableModels),
                typeof(ObservableCollection<string>),
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
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
                typeof(RemoveCarViewControl));
        //=========================================================================
        public ObservableCollection<Car> ListViewCarsCollection
        {
            get { return (ObservableCollection<Car>)GetValue(ListViewCarsCollectionProperty); }

            set { SetValue(ListViewCarsCollectionProperty, value); }
        }

        public static readonly DependencyProperty ListViewCarsCollectionProperty =
            DependencyProperty.Register(
                nameof(ListViewCarsCollection),
                typeof(ObservableCollection<Car>),
                typeof(RemoveCarViewControl));
        //=========================================================================
        public Car ListViewSelectedCar
        {
            get { return (Car)GetValue(ListViewSelectedCarProperty); }

            set { SetValue(ListViewSelectedCarProperty, value); }
        }

        public static readonly DependencyProperty ListViewSelectedCarProperty =
            DependencyProperty.Register(
                nameof(ListViewSelectedCar),
                typeof(Car),
                typeof(RemoveCarViewControl));
        #endregion
    }
}