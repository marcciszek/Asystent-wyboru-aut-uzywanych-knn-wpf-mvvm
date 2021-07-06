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
        private CarsModel carModel = new CarsModel();
        #endregion
        #region Konstruktory
        public MainViewModel()
        {
            carsVM = new CarsViewModel(carModel);
        }
        #endregion
    }
}
