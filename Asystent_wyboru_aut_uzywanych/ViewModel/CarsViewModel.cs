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
        #region Metody
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
        private void Clear_Form()
        {
            Price = "";
            Power = "";
            Mileage = "";
            Age = "";
            Vehicle_type = "";
            Gearbox_type = "";
            Fuel_type = "";
            Brand = "";
            Model = "";
            Damage = "";
        }
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
                return carModel.brands;
            }
        }
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
                MessageBox.Show("elo");
                Update_models_list(selected_brand);
                onPropertyChanged(nameof(Selected_Brand));
            }
        }
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
        private void Update_models_list(string brand)
        {

            models.Clear();
            switch (brand)
            {
                case "Ford":
                    foreach (var item in carModel.models_ford)
                    {
                        models.Add(item.ToString());
                    }
                    break;
                case "BMW":
                    foreach (var item in carModel.models_bmw)
                    {
                        models.Add(item.ToString());
                    }
                    break;
                case "Audi":
                    foreach (var item in carModel.models_audi)
                    {
                        models.Add(item.ToString());
                    }
                    break;
                case "Citroen":
                    foreach (var item in carModel.models_citroen)
                    {
                        models.Add(item.ToString());
                    }
                    break;
            }

        }
        #endregion
    }
}
