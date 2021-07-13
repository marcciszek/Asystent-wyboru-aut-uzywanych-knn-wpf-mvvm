using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using BaseClass;
    using Model;
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Windows.Input;
    using System.Windows;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    using System.IO;
    using Model.History;

    class PredictCarsViewModel : ViewModelBase
    {
        #region definicje prywatne
        private CarsModel carModel = null;
        private PredictModel predictModel = null;


        private ObservableCollection<Car> cars = null;
       

        #endregion
        #region parametry
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
        private Car selected_car = null;

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
        #region liczbowe
        private string price_min = "";
        public string Price_Min
        {
            get
            {
                return price_min;
            }
            set
            {
                price_min = value;
                onPropertyChanged(nameof(Price_Min));

            }
        }
        private string price_max = "";
        public string Price_Max
        {
            get
            {
                return price_max;
            }
            set
            {
                price_max = value;
                onPropertyChanged(nameof(Price_Max));

            }
        }
        private string power = "";
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
        private string mileage = "";
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
        private string age = "";
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
        #region listy wybieralnych
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
        #endregion
        #region Wybrane elementy
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
        #endregion
        #region metody i ICommand
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
                            Clear_Form_PredictVM();
                        }
                        ,//Dodac metode sprawdzajaca?
                        arg => true
                        );
                }
                return clear_form_button;
            }
        }
        private void Clear_Form_PredictVM()
        {

            Price_Min = "";
            Price_Max = "";
            Power = "";
            Mileage = "";
            Age = "";
            //===========================
            Selected_Type = null;
            Selected_Gear = null;
            Selected_Fuel = null;
            Selected_Damage = null;
        }
        //predykcja
        public void predict_start()
        {
            Car_Linguistic car_lin = new Car_Linguistic(selected_type, selected_gear, selected_fuel, null, null, selected_damage);
            try
            {
                int price_min, price_max, power, mileage, age;
                #region Zmiana string do int
                if (Int32.TryParse(this.price_min, out price_min))
                {
                    price_min = Int32.Parse(this.price_min);
                }
                else
                {
                    price_min = 0;
                }
                if (Int32.TryParse(this.price_max, out price_max))
                {
                    price_max = Int32.Parse(this.price_max);
                }
                else
                {
                    price_max = int.MaxValue;
                }
                if (Int32.TryParse(this.power, out power))
                {
                    power = Int32.Parse(this.power);
                }
                else
                {
                    power = 100;
                }
                if (Int32.TryParse(this.mileage, out mileage))
                {
                    mileage = Int32.Parse(this.mileage);
                }
                else
                {
                    mileage = 0;
                }
                if (Int32.TryParse(this.age, out age))
                {
                    age = Int32.Parse(this.age);
                }
                else
                {
                    age = 0;
                }
                if(price_min > price_max)
                {
                    price_max = int.MaxValue;
                }
                #endregion
                Car_Numerical sample = new Car_Numerical(price_min, power, mileage, age);
                Cars = predictModel.Search_For_Cars(car_lin, price_min, price_max);
                Cars = predictModel.Predict(Cars, sample);
                Car car_sample = new Car(car_lin, sample, price_max);
                FileHandling.Write_History_Files(Cars, car_sample);
            }
            catch (Exception)
            {
                MessageBox.Show("Bledna wartosc");
            }
        }

        private void Default_Values()
        {
            Price_Min = "0";
            Price_Max = "";
            Power = "100";
            Mileage = "0";
            string year = Convert.ToString(DateTime.Now.Year);
            Age = year;
            //===========================
            Selected_Type = null;
            Selected_Gear = null;
            Selected_Fuel = null;
            Selected_Damage = null;
        }

        internal void Transaction()
        {
            MessageBox.Show(Selected_Car.ID.ToString());
            if (CarRepository.Insert_Into_Sold(Selected_Car))
            {
                MessageBox.Show("Pomyslnie sprzedano auto!");
            }
            else
            {
                MessageBox.Show("Nie udalo sie sprzedac auta :(");
            }
        }
        #endregion
        #region konstruktory
        public PredictCarsViewModel(CarsModel carModel, PredictModel predictModel)
        {
            this.carModel = carModel;
            this.predictModel = predictModel;
            Default_Values();
        }
        #endregion
    }
}
