using Asystent_wyboru_aut_uzywanych.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    class RemoveModel
    {
        internal bool Remove_Car(Car selected_car)
        {
            bool stan;
            stan = CarRepository.Remove_Car(selected_car);
            return stan;
        }
    }
}
