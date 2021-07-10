using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model.Prediction
{
    using DAL.Encje;
    using DAL.Repozytoria;

    class Algorythm
    {
        public List<Car_Numerical> KNN(List<Car_Numerical> cars, List<Car_Numerical> cars_db)
        {
            MessageBox.Show(cars_db.Count.ToString());
            foreach(var car in cars)
            {
                var sample = Sample.Create_Sample(car);
                
            
            return cars;
        }
    }
}
