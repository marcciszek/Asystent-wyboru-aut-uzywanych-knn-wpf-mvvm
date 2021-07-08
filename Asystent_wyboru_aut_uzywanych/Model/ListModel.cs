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
        #endregion
    }
}
