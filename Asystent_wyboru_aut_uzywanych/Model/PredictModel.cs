using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    using ViewModel;
    using Asystent_wyboru_aut_uzywanych.Model.Prediction;

    class PredictModel
    {
        private Algorythm KNN_Prediction = new Algorythm();
        ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
        #region metody
        public ObservableCollection<Car> Search_For_Cars(Car_Linguistic car_lin, int price_min, int price_max)
        {
            var cars = CarRepository.Search_For_Cars_Prediction(car_lin, price_min, price_max);
            ObservableCollection<Car> cars_collection = new ObservableCollection<Car>();
            foreach (var car in cars)
            {
                cars_collection.Add(car);
            }
            return cars_collection;
        }

        public ObservableCollection<Car> Predict(ObservableCollection<Car> cars, Car_Numerical sample)
        {
            //cars - wszystkie pasujace auta
            List<Car_Numerical> cars_numerical;
            //Pobiera wszystkie wartosci aut numerycznych dla wszystkich wartosci lingwistycznych
            List<Car_Numerical> cars_db = CarsRepository.Get_All_Cars(new Car_Linguistic(null, null, null, null, null, null));
            //cars_numerical - wartosci liczbowe dla wszystkich pasujacych
            cars_numerical = Get_Numerical_Cars(cars);
            cars_numerical = KNN_Prediction.KNN(cars_numerical, cars_db, sample);
            cars = KNNRepository.Get_Cars_By_ID(cars_numerical);
            return cars;
        }

        private List<Car_Numerical> Get_Numerical_Cars(ObservableCollection<Car> cars)
        {
            List<Car_Numerical> cars_numerical = new List<Car_Numerical>();
            foreach(var car in cars)
            {
                cars_numerical.Add(CarsRepository.Get_Numerical_By_Id(car.ID));
            }
            
            return cars_numerical;
        }
        #endregion
    }
}
