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

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand dodaj;

        public ICommand Dodaj
        {
            get
            {
                return dodaj ?? (dodaj = new RelayCommand(
                                                      p => model.Dodawanie_auta(),
                                                      p => 1 < 10 ? true : false
                                                 )
                                  );
            }
        }

        #region Konstruktor
        Model model = new Model();
        #endregion
    }
}
