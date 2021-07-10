﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using DAL;
    using BaseClass;
    using Asystent_wyboru_aut_uzywanych.Model;
    using View;
    using System.Security;
    using System.Windows;

    class MainViewModel : ViewModelBase
    {
        #region Definicje
        public CarsViewModel carsVM { get; set; }
        public ListViewModel listVM { get; set; }
        public RemoveViewModel removeVM { get; set; }
        public PredictCarsViewModel predictVM { get; set; }
        private CarsModel carModel = new CarsModel();
        private ListModel listModel = new ListModel();
        private RemoveModel removeModel = new RemoveModel();
        private PredictModel predictModel = new PredictModel();
        LoginPage newLoginPage;
        PredictResultPage newPredictResultPage;
        
        private string statusString;
        public string StatusString
        {
            get
            {
                return statusString; 
            }
            set
            {
                statusString = value;
                onPropertyChanged(nameof(StatusString));
            }
        }
        
        private uint statusLevel;
        public uint StatusLevel
        {
            get
            {
                return statusLevel;
            }
            set
            {
                statusLevel = value;
                onPropertyChanged(nameof(statusLevel));
            }
        }
        #endregion

        #region Login Window
        private ICommand login_button = null;
        public ICommand Login_Button
        {
            get
            {
                if (login_button == null)
                {
                    login_button = new RelayCommand(
                        arg =>
                        {
                            Login_Method();
                        },
                        arg => (removeVM.Selected_Car != null)
                    );
                }
                return login_button;
            }
        }
        private void Login_Method()
        {
            newLoginPage = new LoginPage(this);
            newLoginPage.Show();
        }
        private ICommand close_button = null;
        public ICommand Close_Button
        {
            get
            {
                if(close_button == null)
                {
                    close_button = new RelayCommand(
                        arg =>
                        {
                            newLoginPage.Close();
                        },
                        arg => true
                        );
                }
                return close_button;
            }
        }
        private ICommand remove_button = null;
        public ICommand Remove_Button
        {
            get
            {
                if (remove_button == null)
                {
                    remove_button = new RelayCommand(
                        arg =>
                        {
                            bool deleted = removeVM.Remove_Selected_Car();
                            newLoginPage.Close();
                            if (deleted)
                            {
                                MessageBox.Show("Usunięto auto z bazy");
                            }
                            else
                            {
                                MessageBox.Show("Nie udało się usunąć auta z bazy");
                            }
                        },
                        arg => true
                        );
                }
                return remove_button;
            }
        }
        #endregion
        
        #region Predict Window
        private ICommand predict_button = null;
        public ICommand Predict_Button
        {
            get
            {
                if (predict_button == null)
                {
                    predict_button = new RelayCommand(
                        arg =>
                        {
                            predictVM.predict_start();
                            Predict_Window();
                        },
                        arg => true
                        );
                }
              return predict_button;
            }
        }
        private ICommand test_add = null;
        public ICommand Test_add
        {
            get
            {
                if (test_add == null)
                {
                    test_add = new RelayCommand(
                        arg =>
                        {
                            StatusLevel += 1;
                            StatusString += "1";
                        },
                        arg => true
                        );
                }
                return test_add;
            }
        }

        private void Predict_Window()
        {
            newPredictResultPage = new PredictResultPage(this);
            newPredictResultPage.Show();
        }
        #endregion
        
        #region Konstruktory
        public MainViewModel()
        {
            carsVM = new CarsViewModel(carModel);
            listVM = new ListViewModel(carModel, listModel);
            predictVM = new PredictCarsViewModel(carModel, listModel, predictModel);
            removeVM = new RemoveViewModel(carModel, listModel, removeModel);
        }
        #endregion
    }
}
