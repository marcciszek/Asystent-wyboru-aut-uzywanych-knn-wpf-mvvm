using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Repozytoria;
    using DAL.Encje;
    class AddCarsModel
    {
        public bool Dodawanie_auta(Car_Numerical car)
        {
            RepozytoriumAuta.DodajAuto(car);
            return true;
        }
    }
}
