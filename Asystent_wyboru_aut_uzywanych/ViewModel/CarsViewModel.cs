using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using Model;
    using DAL.Repozytoria;
    using DAL.Encje;
    using ViewModel.BaseClass;
    using System.Collections.ObjectModel;

    class CarsViewModel : ViewModelBase
    {
        #region Konstruktory
        public CarsViewModel(CarsModel carModel)
        {
            this.carModel = carModel;
        }
        #endregion
        #region definicje prywatne
        private CarsModel carModel = null;
        #endregion

        #region parametry publiczne liczbowe
        private string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                onPropertyChanged(nameof(Price));

            }
        }
        private string power;
        public string Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
                onPropertyChanged(nameof(Power));

            }
        }
        private string mileage;
        public string Mileage
        {
            get
            {
                return mileage;
            }
            set
            {
                mileage = value;
                onPropertyChanged(nameof(Mileage));
            }
        }
        private string age;
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                onPropertyChanged(nameof(Age));
            }
        }
        #endregion
        //Usunac parametry lingwistyczne
        #region parametry publiczne lingwistycznie
        private string vehicle_type;
        public string Vehicle_type
        {
            get
            {
                return vehicle_type;
            }
            set
            {
                vehicle_type = value;
                onPropertyChanged(nameof(Vehicle_type));
            }
        }
        private string gearbox_type;
        public string Gearbox_type
        {
            get
            {
                return gearbox_type;
            }
            set
            {
                gearbox_type = value;
                onPropertyChanged(nameof(Gearbox_type));
            }
        }
        private string fuel_type;
        public string Fuel_type
        {
            get
            {
                return fuel_type;
            }
            set
            {
                fuel_type = value;
                onPropertyChanged(nameof(Fuel_type));
            }
        }
        private string brand;
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
                onPropertyChanged(nameof(Brand));
            }
        }
        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                onPropertyChanged(nameof(Model));
            }
        }
        private string damage;
        public string Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
                onPropertyChanged(nameof(Damage));
            }
        }
        #endregion
        //===========================
        #region parametry usercontrol
        #region Elementy W Listach
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
                return brands.ToArray() ;
            }
        }
        #endregion
        #region Wybrane elementy
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
        #region Metody

        //Usunac stara metode dodajaca auta do bazy
        private ICommand add_car = null;

        public ICommand Add_car
        {
            get
            {
                if (add_car == null)
                {
                    add_car = new RelayCommand(
                        arg =>
                        {
                            // Usunac sprawdzanie intow jak beda suwaki w UI
                            try
                            {
                                int price = Int32.Parse(this.price);
                                int power = Int32.Parse(this.power);
                                int mileage = Int32.Parse(this.mileage);
                                int age = Int32.Parse(this.age);
                                var Car_num = new Car_Numerical(price, power, mileage, age);
                                var Car_lin = new Car_Linguistic(vehicle_type, gearbox_type, fuel_type, brand, model, damage);
                                if (carModel.Add_car(Car_num, Car_lin))
                                {
                                    //Dodac metode czyszczaca formularz
                                    Clear_Form();
                                    MessageBox.Show("Dodano auto do bazy");
                                }
                                else
                                {
                                    MessageBox.Show("Nie udało się dodać auta do bazy");
                                }
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Nie udało się dodać auta do bazy");
                            }
                        }
                        ,//Dodac metode sprawdzajaca?
                        arg => (Price != "") && (Power != "") && (Mileage != "") && (Age != "")
                        );
                }
                return add_car;
            }
        }
        //================================
        private void Clear_Form()
        {
            
            Price = "";
            Power = "";
            Mileage = "";
            Age = "";
            //===========================
            Selected_Type = null;
            Selected_Gear = null;
            Selected_Fuel = null;
            Selected_Brand = null;
            Selected_Model = null;
            Selected_Damage = null;
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
        private ICommand add_car_control = null;

        public ICommand Add_car_control
        {
            get
            {
                if (add_car_control == null)
                {
                    add_car_control = new RelayCommand(
                        arg =>
                        {
                            try
                            {
                                int price = Int32.Parse(this.price);
                                int power = Int32.Parse(this.power);
                                int mileage = Int32.Parse(this.mileage);
                                int age = Int32.Parse(this.age);
                                var Car_num = new Car_Numerical(price, power, mileage, age);
                                var Car_lin = new Car_Linguistic(Selected_Type, Selected_Gear, Selected_Fuel, Selected_Brand, Selected_Model, Selected_Damage);
                                if (carModel.Add_car(Car_num, Car_lin))
                                {
                                    //Dodac metode czyszczaca formularz
                                    Clear_Form();
                                    MessageBox.Show("Dodano auto do bazy");
                                }
                                else
                                {
                                    MessageBox.Show("Nie udało się dodać auta do bazy");
                                }
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Nie udało się dodać auta do bazy");
                            }
                        }
                        ,//Dodac metode sprawdzajaca?
                        arg => (Price != "") && (Power != "") && (Mileage != "") && (Age != "")
                        );
                }
                return add_car_control;
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
                        }
                        ,//Dodac metode sprawdzajaca?
                        arg => true
                        );
                }
                return clear_form_button;
            }
        }
        #endregion
    }
}
