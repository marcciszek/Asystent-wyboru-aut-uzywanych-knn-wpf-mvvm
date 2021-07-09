using System;
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
        private CarsModel carModel = new CarsModel();
        private ListModel listModel = new ListModel();
        private RemoveModel removeModel = new RemoveModel();
        LoginPage newLoginPage;
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
        private ICommand remove_button;
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
