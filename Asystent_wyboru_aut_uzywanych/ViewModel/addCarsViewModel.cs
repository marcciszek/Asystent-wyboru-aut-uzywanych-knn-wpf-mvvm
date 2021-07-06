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

    class addCarsViewModel : ViewModelBase
    {
        #region Konstruktory
        public addCarsViewModel(Model model, AddCarsModel addModel)
        {
            this.model = model;
            this.addModel = addModel;
        }
        #endregion
        #region definicje prywatne
        private Model model = null;
        private AddCarsModel addModel = null;
        #endregion

        #region parametry publiczne
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
                            try
                            {
                                int price = Int32.Parse(this.price);
                                int power = Int32.Parse(this.power);
                                int mileage = Int32.Parse(this.mileage);
                                int age = Int32.Parse(this.age);
                                var Car_num = new Car_Numerical(price, power, mileage, age);
                                if (addModel.Dodawanie_auta(Car_num))
                                {
                                    Price = "";
                                    Power = "";
                                    Mileage = "";
                                    Age = "";
                                    MessageBox.Show("Dodano auto do bazy");
                                }
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Nie udało się dodać auta do bazy");
                            }
                        }
                        ,
                        arg => (Price != "") && (Power != "") && (Mileage != "") && (Age != "")
                        );
                }
                return add_car;
            }
        }
        #endregion
    }
}
