using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.DAL.Encje
{
    class Car_Numerical
    {
        #region Parametry
        public int Price { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public int Age { get; set; }
        #endregion

        #region konstruktory
        public Car_Numerical(int Price, int Power, int Mileage, int Age)
        {
            this.Price = Price;
            this.Power = Power;
            this.Mileage = Mileage;
            this.Age = Age;
        }
        #endregion

        #region metody
        public string Insert_To_Database()
        {
            return $"('{Price}', '{Power}', '{Mileage}', '{Age}')";
        }
        #endregion
    }
}
