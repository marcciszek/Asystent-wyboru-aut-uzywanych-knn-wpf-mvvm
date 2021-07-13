using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model.Prediction
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using Asystent_wyboru_aut_uzywanych.Model.Prediction.Prediction_objects;

    class Algorythm
    {
        #region metody
        public List<Car_Numerical> KNN(List<Car_Numerical> cars, List<Car_Numerical> cars_db, Car_Numerical sample_numerical)
        {
            List<Car_Normalized> cars_norm = Normalization.Normalize_database(cars);
            var sample = Sample_creation.Create_Sample(sample_numerical);
            sample = Normalization.Normalize_sample(sample, cars_norm);
            List<double> distances = new List<double>();
            foreach(var car in cars_norm)
            {
                distances.Add(Metric(sample, car, 2));
            }
            //Sortowanie zbioru wedlug odleglosci
            int Number_of_shown_cars = 10;
            if(Number_of_shown_cars < cars_norm.Count)
            {
                Number_of_shown_cars = cars_norm.Count;
            }
            for(int i = 0; i < Number_of_shown_cars; i++)
            {
                for(int j = i; j < distances.Count; j++)
                {
                    if(distances[i] > distances[j])
                    {
                        //Zamiana miejsc dystanse
                        double temp_distance = distances[i];
                        distances[i] = distances[j];
                        distances[j] = temp_distance;
                        //Zamiana miejsc cars
                        Car_Normalized temp_car = cars_norm[i];
                        cars_norm[i] = cars_norm[j];
                        cars_norm[j] = temp_car;
                    }
                }
            }
            cars = Normalization.Unnormalize_database(cars_norm);
            return cars;
        }
        private static double Metric(Dictionary<string, double> sample, Car_Normalized db_record, int m)
        {
            double distance = 0;

            //Sum of elements
            distance += Math.Pow(Math.Abs(sample["Price"] - db_record.Price), 2);
            distance += Math.Pow(Math.Abs(sample["Power"] - db_record.Power), 2);
            distance += Math.Pow(Math.Abs(sample["Mileage"] - db_record.Mileage), 2);
            distance += Math.Pow(Math.Abs(sample["Age"] - db_record.Age), 2);
            //Square root
            distance = Math.Sqrt(distance);
            return distance;
        }
        #endregion
    }
}
