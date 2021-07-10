using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model.Prediction.Prediction_objects
{
    class Car_Normalized
    {
        #region Parametry
        public int ID { get; set; }
        public double Price { get; set; }
        public double Power { get; set; }
        public double Mileage { get; set; }
        public double Age { get; set; }
        #endregion

        #region konstruktory
        public Car_Normalized(int ID, double Price, double Power, double Mileage, double Age)
        {
            this.ID = ID;
            this.Price = Price;
            this.Power = Power;
            this.Mileage = Mileage;
            this.Age = Age;
        }
        #endregion
    }
}
