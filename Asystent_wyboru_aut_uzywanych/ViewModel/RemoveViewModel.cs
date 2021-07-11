﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Security;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using View;
    using ViewModel.SharedMethods;
    

    class RemoveViewModel : ViewModelBase
    {
        #region skladowe prywatne
        private CarsModel carModel = null;
        private ListModel listModel = null;
        private RemoveModel removeModel = null;
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

        #region parametry
        #region wybieralne
        public string[] Damages
        {
            get
            {
                return carModel.damage;
            }
        }
        public string[] Fuels
        {
            get
            {
                return carModel.fuel_type;
            }
        }
        public string[] Gears
        {
            get
            {
                return carModel.gearbox_type;
            }
        }
        public string[] Types
        {
            get
            {
                return carModel.vehicle_type;
            }
        }
        public string[] Brands
        {
            get
            {
                List<string> brands = new List<string>(carModel.brands.Keys);
                return brands.ToArray();
            }
        }
        #endregion
        #region Wybrane
        private string selected_brand;
        public string Selected_Brand
        {
            get
            {
                return selected_brand;
            }
            set
            {
                selected_brand = value;
                models = ViewModelSharedMethods.Update_models_list(selected_brand, models);
                onPropertyChanged(nameof(Selected_Brand));
            }
        }
        private string selected_model;
        public string Selected_Model
        {
            get
            {
                return selected_model;
            }
            set
            {
                selected_model = value;
                onPropertyChanged(nameof(Selected_Model));
            }
        }
        private string selected_type;
        public string Selected_Type
        {
            get
            {
                return selected_type;
            }
            set
            {
                selected_type = value;
                onPropertyChanged(nameof(Selected_Type));
            }
        }
        private string selected_gear;
        public string Selected_Gear
        {
            get
            {
                return selected_gear;
            }
            set
            {
                selected_gear = value;
                onPropertyChanged(nameof(Selected_Gear));
            }
        }
        private string selected_fuel;
        public string Selected_Fuel
        {
            get
            {
                return selected_fuel;
            }
            set
            {
                selected_fuel = value;
                onPropertyChanged(nameof(Selected_Fuel));
            }
        }
        private string selected_damage;
        public string Selected_Damage
        {
            get
            {
                return selected_damage;
            }
            set
            {
                selected_damage = value;
                onPropertyChanged(nameof(Selected_Damage));
            }
        }
        private Car selected_car;
        public Car Selected_Car
        {
            get
            {
                return selected_car;
            }
            set
            {
                selected_car = value;
                onPropertyChanged(nameof(Selected_Car));
            }
        }
        #endregion
        private ObservableCollection<string> models = new ObservableCollection<string>();
        public ObservableCollection<string> Models
        {
            get
            {
                return models;
            }
            set
            {
                onPropertyChanged(nameof(Models));
            }
        }
        #endregion
        #region metody
        private ICommand search_for_cars = null;
        public ICommand Search_For_Cars
        {
            get
            {
                if (search_for_cars == null)
                {
                    search_for_cars = new RelayCommand(
                        arg =>
                        {
                            var Car_lin = new Car_Linguistic(Selected_Type, Selected_Gear, Selected_Fuel, Selected_Brand, Selected_Model, Selected_Damage);
                            Cars = listModel.Search_For_Cars(Car_lin);
                        },
                        arg => true
                        );
                }
                return search_for_cars;
            }
        }

        private ICommand clear_form_button = null;
        public ICommand Clear_Form_Button
        {
            get
            {
                if (clear_form_button == null)
                {
                    clear_form_button = new RelayCommand(
                        arg =>
                        {
                            Clear_Form_RemoveVM();
                            var Car_lin = new Car_Linguistic(Selected_Type, Selected_Gear, Selected_Fuel, Selected_Brand, Selected_Model, Selected_Damage);
                            Cars = listModel.Search_For_Cars(Car_lin);
                        }
                        ,//Dodac metode sprawdzajaca?
                        arg => true
                        );
                }
                return clear_form_button;
            }
        }
        public bool Remove_Selected_Car()
        {
            if (removeModel.Remove_Car(selected_car, SecurePassword, user_login))
            {
                //Dodac metode czyszczaca formularz
                Clear_Form_RemoveVM();
                var Car_lin = new Car_Linguistic(null, null, null, null, null, null);
                Cars = listModel.Search_For_Cars(Car_lin);
                User_Login = null;
                SecurePassword = null;
                return true;
            }
            else
            {
                User_Login = null;
                SecurePassword = null;
                return false;
            }
            //metoda remove car(id_auta)
        }
        private void Clear_Form_RemoveVM()
        {
            Selected_Type = null;
            Selected_Gear = null;
            Selected_Fuel = null;
            Selected_Brand = null;
            Selected_Model = null;
            Selected_Damage = null;
        }
        
        #endregion
        #region Logowanie uzytkownika do usuwania
        
        public SecureString SecurePassword { private get; set; }

        private string user_password;
        public string User_Password
        {
            get 
            { 
                return user_password;
            }
            set
            {
                user_password = value;
                onPropertyChanged(nameof(User_Password));
            }
        }
        private string user_login;
        public string User_Login
        {
            get
            {
                return user_login;
            }
            set
            {
                user_login = value;
                onPropertyChanged(nameof(User_Login));
            }
        }
        #endregion
        #region konstruktory
        public RemoveViewModel(CarsModel carModel, ListModel listModel, RemoveModel removeModel)
        {
            this.carModel = carModel;
            this.listModel = listModel;
            this.removeModel = removeModel;
            this.User_Login = Properties.Settings.Default.user_default;
        }
        #endregion
    }
}
