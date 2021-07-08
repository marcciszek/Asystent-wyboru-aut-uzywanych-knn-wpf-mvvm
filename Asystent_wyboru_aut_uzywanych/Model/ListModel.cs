using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class ListModel
    {
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();

        #region konstruktory
        public ListModel()
        {
            var cars = CarRepository.Get_all_cars();
            foreach(var car in cars)
            {
                Cars.Add(car);
            }
        }

        public ObservableCollection<Car> Search_For_Cars(Car_Linguistic car_lin)
        {
            var cars = CarRepository.Search_For_Cars(car_lin);
            ObservableCollection<Car> cars_collection = new ObservableCollection<Car>();
            foreach(var car in cars)
            {
                cars_collection.Add(car);
            }
            return cars_collection;
        }
        #endregion
    }
}
