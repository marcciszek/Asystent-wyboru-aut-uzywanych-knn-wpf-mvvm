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
        #region Konstruktory i definicje
        public addCarsViewModel addVM { get; set; }
        private Model model = new Model();
        private AddCarsModel addModel = new AddCarsModel();

        public MainViewModel()
        {
            addVM = new addCarsViewModel(model, addModel);
        }
        #endregion
    }
}
