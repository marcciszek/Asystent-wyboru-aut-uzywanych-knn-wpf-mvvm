using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    using DAL.Encje;
    class CarsRepository
    {
        #region Zapytania
        private const string ADD_CAR_LING = "INSERT INTO `cars_linguistic`(`body_type`, `gearbox_type`, `model`, `fuel_type`, `brand`, `repaired`) VALUES";
        private const string ADD_CAR_NUM = "INSERT INTO `cars_numerical`(`price`, `power`, `mileage`, `age`) VALUES";
        #endregion

        #region Metody
        public static bool Add_car(Car_Numerical car_num, Car_Linguistic car_lin)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_ling = new MySqlCommand($"{ADD_CAR_LING} {car_lin.Insert_To_Database()}", connection);
                MySqlCommand command_num = new MySqlCommand($"{ADD_CAR_NUM} {car_num.Insert_To_Database()}", connection);
                try
                {
                    connection.Open();
                    command_ling.ExecuteNonQuery();
                    command_num.ExecuteNonQuery();
                    stan = true;
                    connection.Close();
                }
                catch (Exception)
                {
                    stan = false;
                }
            }
            return stan;
        }
        #endregion
    }
}
