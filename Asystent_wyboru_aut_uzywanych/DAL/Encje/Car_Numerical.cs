using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.DAL.Encje
{
    class Car_Numerical
    {
        #region Parametry
        public int ID { get; set; }
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
        public Car_Numerical(MySqlDataReader reader)
        {
            this.ID = int.Parse(reader[0].ToString());
            this.Price = int.Parse(reader[1].ToString());
            this.Power = int.Parse(reader[2].ToString());
            this.Mileage = int.Parse(reader[3].ToString());
            this.Age = int.Parse(reader[4].ToString());
        }
        #endregion

        #region metody
        public string Insert_To_Database()
        {
            return $"('{Price}', '{Power}', '{Mileage}', '{Age}')";
        }
        public string Select_In_Database()
        {
            return $"price LIKE '{Price}' AND power LIKE '{Power}' AND mileage LIKE '{Mileage}' AND age LIKE '{Age}'";
        }
        #endregion
    }
}
