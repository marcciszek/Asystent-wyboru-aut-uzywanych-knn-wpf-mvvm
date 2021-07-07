using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Repozytoria;
    using DAL.Encje;
    class CarsModel
    {
        #region tablice stałych
        //Tablica marek samochodów
        public string[] brands = new string[] { "Audi", "BMW", "Citroen", "Ford" };
        public string[] models_audi = new string[] { "A3", "A4", "A5", "R8" };
        public string[] models_bmw = new string[] { "Seria 3", "Seria 5", "X5" };
        public string[] models_citroen = new string[] { "C3", "C4", "C5" };
        public string[] models_ford = new string[] { "Focus", "Mondeo", "Puma", "Kuga" };
        //Tablice nadwozi, skrzyn, paliwa i uszkodzen
        public string[] vehicle_type = new string[] { "sedan", "coupe", "cabrio", "kompakt", "kombi", "suv", "bus", "other" };
        public string[] gearbox_type = new string[] { "manual", "automatic" };
        public string[] fuel_type = new string[] { "diesel", "petrol", "lpg", "hybrid", "electric", "cng", "other" };
        public string[] damage = new string[] { "yes", "no" };

        #endregion
        public bool Add_car(Car_Numerical car_num, Car_Linguistic car_lin)
        {
            bool stan;
            stan = CarsRepository.Add_car(car_num, car_lin);
            return stan;
        }
    }
}
