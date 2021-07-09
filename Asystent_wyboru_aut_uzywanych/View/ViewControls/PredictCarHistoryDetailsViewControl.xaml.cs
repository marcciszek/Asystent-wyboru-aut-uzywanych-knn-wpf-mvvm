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

namespace Asystent_wyboru_aut_uzywanych.View.ViewControls
{
    using DAL.Encje;
    /// <summary>
    /// Logika interakcji dla klasy PredictCarHistoryDetailsViewControl.xaml
    /// </summary>
    public partial class PredictCarHistoryDetailsViewControl : UserControl
    {
        public PredictCarHistoryDetailsViewControl()
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
                typeof(PredictCarHistoryDetailsViewControl));
        //=========================================================================
    }
}
