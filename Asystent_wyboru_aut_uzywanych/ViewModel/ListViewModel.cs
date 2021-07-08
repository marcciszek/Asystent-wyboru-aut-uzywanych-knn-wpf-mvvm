using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;

    class ListViewModel: ViewModelBase
    {
        #region skladowe prywatne
        private CarsModel carModel = null;
        private ListModel listModel = null;
        private ObservableCollection<Car> cars = null;
        #endregion

        #region skladowe publiczne
        public ObservableCollection<Car> Cars
        {
            get 
            { 
                return cars; 
            }
            set
            {
                cars = value;
                onPropertyChanged(nameof(Cars));
            }
        }
        #endregion

        #region metody
        private ICommand load_cars = null;
        public ICommand Load_Cars
        {
            get
            {
                if(load_cars == null)
                {
                    load_cars = new RelayCommand(
                        arg =>
                        {
                            Cars = listModel.Cars;
                        },
                        arg => true
                        );
                }
                return load_cars;
            }
        }
        #endregion
        #region konstruktory
        public ListViewModel(CarsModel carModel, ListModel listModel)
        {
            this.carModel = carModel;
            this.listModel = listModel;
        }
        #endregion
    }
}
