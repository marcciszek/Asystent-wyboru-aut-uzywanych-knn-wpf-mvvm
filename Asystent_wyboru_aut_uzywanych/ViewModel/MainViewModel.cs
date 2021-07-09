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
            LoginPage newLoginPage = new LoginPage(removeVM);
            newLoginPage.Show();
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
