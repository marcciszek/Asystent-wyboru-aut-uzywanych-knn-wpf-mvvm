using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    using DAL.Encje;
    class RepozytoriumAuta
    {
        #region ZAPYTANIA
        private const string DODAJ_AUTO_LING = "INSERT INTO `cars_linguistic`(`body_type`, `gearbox_type`, `model`, `fuel_type`, `brand`, `repaired`) VALUES";
        private const string DODAJ_AUTO_NUM = "INSERT INTO `cars_numerical`(`price`, `power`, `mileage`, `age`) VALUES";
        #endregion

        public static bool DodajAuto(Car_Numerical car)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_ling = new MySqlCommand($"{DODAJ_AUTO_LING} {"('kombi', 'manual', 'mondeo', 'diesel', 'ford', 'no')"}", connection);
                MySqlCommand command_num = new MySqlCommand($"{DODAJ_AUTO_NUM} {car.ToInsert()}", connection);
                connection.Open();
                var id_ling = command_ling.ExecuteNonQuery();
                var id_num = command_num.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
