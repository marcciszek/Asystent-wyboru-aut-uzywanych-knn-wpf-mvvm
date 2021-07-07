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
        public bool Add_car(Car_Numerical car_num, Car_Linguistic car_lin)
        {
            bool stan;
            stan = CarsRepository.Add_car(car_num, car_lin);
            return stan;
        }
    }
}
