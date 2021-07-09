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
    /// Logika interakcji dla klasy PredictCarResultsViewControl.xaml
    /// </summary>
    public partial class PredictCarResultsViewControl : UserControl
    {
        public PredictCarResultsViewControl()
        {
            InitializeComponent();
        }

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
                typeof(PredictCarResultsViewControl));
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
                typeof(PredictCarResultsViewControl));
        //=========================================================================
    }
}
