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
    /// Logika interakcji dla klasy PredictCarHistoryViewControl.xaml
    /// </summary>
    public partial class PredictCarHistoryViewControl : UserControl
    {
        public PredictCarHistoryViewControl()
        {
            InitializeComponent();
        }

        //=========================================================================
        public ObservableCollection<Object> ListViewCarsHistoryCollection
        {
            get { return (ObservableCollection<Object>)GetValue(ListViewCarsHistoryCollectionProperty); }

            set { SetValue(ListViewCarsHistoryCollectionProperty, value); }
        }

        public static readonly DependencyProperty ListViewCarsHistoryCollectionProperty =
            DependencyProperty.Register(
                nameof(ListViewCarsHistoryCollection),
                typeof(ObservableCollection<Object>),
                typeof(PredictCarHistoryViewControl));
        //=========================================================================
        public Object ListViewSelectedHistoryItem
        {
            get { return (Object)GetValue(ListViewSelectedHistoryItemProperty); }

            set { SetValue(ListViewSelectedHistoryItemProperty, value); }
        }

        public static readonly DependencyProperty ListViewSelectedHistoryItemProperty =
            DependencyProperty.Register(
                nameof(ListViewSelectedHistoryItem),
                typeof(Object),
                typeof(PredictCarHistoryViewControl));
        //=========================================================================
    }
}
