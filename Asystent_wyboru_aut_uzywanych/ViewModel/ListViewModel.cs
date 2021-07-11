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
                Update_models_list(selected_brand);
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
        private ICommand search_for_cars = null;
        public ICommand Search_For_Cars
        {
            get
            {
                if(search_for_cars == null)
                {
                    search_for_cars = new RelayCommand(
                        arg =>
                        {
                            System.Windows.MessageBox.Show(":");
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
                            Clear_Form();
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
        private void Update_models_list(string brand)
        {
            if (models.Count != 0)
            {
                models.Clear();
            }
            if (selected_brand != null)
            {
                foreach (var model in carModel.brands[brand])
                {
                    models.Add(model);
                }
            }
        }
        private void Clear_Form()
        {
            Selected_Type = null;
            Selected_Gear = null;
            Selected_Fuel = null;
            Selected_Brand = null;
            Selected_Model = null;
            Selected_Damage = null;
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
