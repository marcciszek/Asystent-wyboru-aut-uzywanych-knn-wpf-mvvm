using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using DAL;
    using BaseClass;
    using Asystent_wyboru_aut_uzywanych.Model;

    class MainViewModel : ViewModelBase
    {
        #region Definicje
        public CarsViewModel carsVM { get; set; }
        public ListViewModel listVM { get; set; }
        public RemoveViewModel removeVM { get; set; }
        private CarsModel carModel = new CarsModel();
        private ListModel listModel = new ListModel();
        private RemoveModel removeModel = new RemoveModel();
        #endregion
        #region Konstruktory
        public MainViewModel()
        {
            carsVM = new CarsViewModel(carModel);
            listVM = new ListViewModel(carModel, listModel);
            removeVM = new RemoveViewModel(carModel, listModel, removeModel);
        }
        #endregion
    }
}
