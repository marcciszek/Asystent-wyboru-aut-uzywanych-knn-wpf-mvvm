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
        internal bool Remove_Car(Car selected_car, string password, string login)
        {
            bool stan;
            if(login == null)
            {
                if (password == null)
                {
                    stan = CarRepository.Remove_Car(selected_car);
                }
                else
                {
                    stan = CarRepository.Remove_Car(selected_car, password);
                }
            }
            else
            {
                stan = CarRepository.Remove_Car(selected_car, password, login);
            }
            return stan;
        }
    }
}
