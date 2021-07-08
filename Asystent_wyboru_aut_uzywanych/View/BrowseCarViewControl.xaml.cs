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
    /// Logika interakcji dla klasy BrowseCarViewControl.xaml
    /// </summary>
    public partial class BrowseCarViewControl : UserControl
    {
        public BrowseCarViewControl()
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
        //-------------------------------------------------------------------------
        public string[] AvailableModels
        {
            get { return (string[])GetValue(AvailableModelsProperty); }
            set { SetValue(AvailableModelsProperty, value); }
        }

        public static readonly DependencyProperty AvailableModelsProperty =
            DependencyProperty.Register(
                nameof(AvailableModels),
                typeof(string[]),
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
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
                typeof(AddCarViewControl));
        //=========================================================================
        public ObservableCollection<Object> ListViewCarsCollection
        {
            get { return (ObservableCollection<Object>)GetValue(ListViewCarsCollectionProperty); }
            set { SetValue(ListViewCarsCollectionProperty, value); }
        }

        public static readonly DependencyProperty ListViewCarsCollectionProperty =
            DependencyProperty.Register(
                nameof(ListViewCarsCollection),
                typeof(ObservableCollection<Object>),
                typeof(AddCarViewControl));
        //=========================================================================


        #endregion
    }
}
