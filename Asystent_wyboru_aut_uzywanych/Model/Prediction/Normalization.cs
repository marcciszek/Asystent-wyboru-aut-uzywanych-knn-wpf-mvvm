using Asystent_wyboru_aut_uzywanych.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model.Prediction
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Windows;
    using Asystent_wyboru_aut_uzywanych.Model.Prediction.Prediction_objects;

    class Normalization
    {
        
        internal static List<Car_Normalized> Normalize_database(List<Car_Numerical> cars)
        {

            List<Car_Normalized> cars_norm = new List<Car_Normalized>();
            foreach(var car in cars)
            {
                cars_norm.Add(new Car_Normalized(car.ID, Convert.ToDouble(car.Price), Convert.ToDouble(car.Power),
                                                 Convert.ToDouble(car.Mileage), Convert.ToDouble(car.Age)));
            }
            Car_Numerical max_values = null;
            Car_Numerical min_values = null;
            //Wartosci minimalne i maksymalne
            max_values = KNNRepository.Find_Max_Values();
            min_values = KNNRepository.Find_Min_Values();
            foreach (var car in cars_norm)
            {
                car.Age = (car.Age - min_values.Age ) / max_values.Age;
                car.Mileage = (car.Mileage - min_values.Mileage ) / max_values.Mileage;
                car.Power = (car.Power - min_values.Power ) / max_values.Power;
                car.Price = (car.Price - min_values.Price )/ max_values.Price;
            }
            return cars_norm;
        }

        internal static Dictionary<string, double> Normalize_sample(Dictionary<string, double> sample, List<Car_Normalized> cars_db)
        {
            Dictionary<string, double> sample_normalized = sample;
            Car_Numerical max_values = null;
            Car_Numerical min_values = null;
            //Wartosci minimalne - maksymalne
            max_values = KNNRepository.Find_Max_Values();
            min_values = KNNRepository.Find_Min_Values();
            sample_normalized["Price"] = (sample_normalized["Price"] - min_values.Price) / max_values.Price;
            sample_normalized["Power"] = (sample_normalized["Power"] - min_values.Power) / max_values.Power;
            sample_normalized["Mileage"] = (sample_normalized["Mileage"] - min_values.Mileage) / max_values.Mileage;
            sample_normalized["Age"] = (sample_normalized["Age"] - min_values.Age) / max_values.Age;
            return sample_normalized;
        }

        internal static List<Car_Numerical> Unnormalize_database(List<Car_Normalized> cars)
        {
            List<Car_Numerical> cars_unnorm = new List<Car_Numerical>();

            Car_Numerical max_values = null;
            Car_Numerical min_values = null;
            //Wartosci minimalne i maksymalne
            max_values = KNNRepository.Find_Max_Values();
            min_values = KNNRepository.Find_Min_Values();

            foreach (var car in cars)
            {
                car.Age = ( car.Age * max_values.Age ) + min_values.Age;
                car.Mileage = (car.Mileage * max_values.Mileage) + min_values.Mileage;
                car.Power = (car.Power * max_values.Power) + min_values.Power;
                car.Price = (car.Price * max_values.Price) + min_values.Price;
            }

            foreach (var car in cars)
            {
                cars_unnorm.Add(new Car_Numerical(car.ID, Convert.ToInt32(car.Price), Convert.ToInt32(car.Power),
                                                 Convert.ToInt32(car.Mileage), Convert.ToInt32(car.Age)));
            }
            return cars_unnorm;
        }
    }
}
