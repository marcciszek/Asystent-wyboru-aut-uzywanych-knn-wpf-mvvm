using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model.Prediction
{
    using DAL.Encje;
    using DAL.Repozytoria;
    class Sample
    {
        public static Dictionary<string, double> Create_Sample(Car_Numerical car)
        {
            Dictionary<string, double> sample = new Dictionary<string, double>();
            sample.Add("Price", Convert.ToDouble(car.Price));
            sample.Add("Power", Convert.ToDouble(car.Power));
            sample.Add("Mileage", Convert.ToDouble(car.Mileage));
            sample.Add("Age", Convert.ToDouble(car.Age));
            return sample;
        }
    }
}
