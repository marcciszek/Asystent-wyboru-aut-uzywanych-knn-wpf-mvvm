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
        public List<Car_Numerical> KNN(List<Car_Numerical> cars, List<Car_Numerical> cars_db, Car_Numerical sample_numerical)
        {
            //Normalizacja bazy
            List<Car_Normalized> cars_norm = Normalization.Normalize_database(cars);
            //Przygotowanie probki jako dictionary
            var sample = Sample.Create_Sample(sample_numerical);
            //Normalizacja probki
            sample = Normalization.Normalize_sample(sample, cars_norm);
            //Obliczenie odleglosci
            List<double> distances = new List<double>();
            foreach(var car in cars_norm)
            {
                distances.Add(Metric(sample, car, 2));
            }
            //Sortowanie zbioru wedlug odleglosci
            //k -> ilosc wyswietlanych aut w liscie
            int k = 10;
            if(k < cars_norm.Count)
            {
                k = cars_norm.Count;
            }
            for(int i = 0; i < k; i++)
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
            //"odnormalizowanie" cars_norm -> Wyniku predykcji
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
    }
}
